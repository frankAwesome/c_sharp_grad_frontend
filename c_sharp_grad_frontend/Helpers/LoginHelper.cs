using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace c_sharp_grad_frontend.Helpers
{
    public class LoginHelper
    {
        public LoginHelper(IConfiguration configuration, IToken _token)
        {
            Configuration = configuration;
            token = _token;
        }
        public IConfiguration Configuration { get; }
        public IToken token { get; }

        public async Task<bool> CallAuthService(User model)
        {   
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");                
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            var response = await httpClient.PostAsync(Configuration.GetConnectionString("LoginService"), httpContent);
            var responseString = await response.Content.ReadAsStringAsync();
            token.token = (JsonConvert.DeserializeObject<Token>(responseString)).token;

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}