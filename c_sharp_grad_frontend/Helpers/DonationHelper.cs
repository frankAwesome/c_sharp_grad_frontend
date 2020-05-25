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
    public class DonationHelper
    {
        IConfiguration configuration;
        IToken token;
        List<Donations> donateList;

        public DonationHelper(IConfiguration _configuration, IToken _token)
        {
            configuration = _configuration;
            token = _token;

            donateList = new List<Donations>();
        }


        public async Task<List<Donations>> GetDonationsForUser(string username)
        {
            donateList.Clear();
            var dtoProfileUser = new { Username = token.username };
            var json = JsonConvert.SerializeObject(dtoProfileUser);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.token);
            var response = await httpClient.PostAsync(configuration.GetConnectionString("GetUserDonationsService"), httpContent);
            Console.WriteLine(response.StatusCode.ToString());

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);

            this.donateList = JsonConvert.DeserializeObject<List<Donations>>(responseString);

            if (response.StatusCode == HttpStatusCode.OK)
                return this.donateList;
            else
                return null;
        }

        public async Task<bool> PostDonation(decimal amount)
        {
            Donations donation = new Donations();
            donation.Username = token.username;
            donation.Amount = amount;
            donation.TimeStamp = DateTime.Now;
            donation.OrganizationId = 1;

            var json = JsonConvert.SerializeObject(donation);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.token);
            var response = await httpClient.PostAsync(configuration.GetConnectionString("PostDonationService"), httpContent);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Created)
                return true;
            else
                return false;
        }


        public async Task<List<Donations>> GetAllDonations()
        {
            donateList.Clear();
            //var httpContent = new StringContent(null, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.token);
            var response = await httpClient.GetAsync(configuration.GetConnectionString("DonateService"));
            Console.WriteLine(response.StatusCode.ToString());

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);

            this.donateList = JsonConvert.DeserializeObject<List<Donations>>(responseString);

            if (response.StatusCode == HttpStatusCode.OK)
                return this.donateList;
            else
                return null;
        }
    }
}
