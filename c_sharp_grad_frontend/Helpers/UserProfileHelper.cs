using c_sharp_grad_frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_grad_frontend.Helpers
{
    public class UserProfileHelper
    {
        IToken token;
        IConfiguration configuration;
        private UserProfile userProfile;

        public UserProfileHelper(IConfiguration _configuration, IToken _token)
        {
            this.token = _token;
            this.configuration = _configuration;

        }

        public async Task<UserProfile> GetProfile(string username)
        {
            var dtoProfileUser = new { Username = username };
            var json = JsonConvert.SerializeObject(dtoProfileUser);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.token);
            var response = await httpClient.PostAsync(configuration.GetConnectionString("GetUserProfileService"),httpContent);
            Console.WriteLine(response.StatusCode.ToString());

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);

            this.userProfile = JsonConvert.DeserializeObject<UserProfile>(responseString);

            if (response.StatusCode == HttpStatusCode.OK)
                return this.userProfile;
            else
                return null;
        }


        public async Task<bool> PostProfile(IUserProfile userProfile)
        {
            var json = JsonConvert.SerializeObject(userProfile);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            var response = await httpClient.PostAsync(configuration.GetConnectionString("PostUserProfileService"), httpContent);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Created)
                return true;
            else
                return false;
        }



        public async Task<bool> EditProfile(IUserProfile userProfile)
        {
            var json = JsonConvert.SerializeObject(userProfile);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            //Update profile
            var response = await httpClient.PutAsync(configuration.GetConnectionString("EditUserProfileService"), httpContent);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
