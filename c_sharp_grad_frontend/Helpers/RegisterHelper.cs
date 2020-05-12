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
    public class RegisterHelper
    {

        public RegisterHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public async Task<bool> CallAuthService(User model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient(SSLHelper.GetSSL());
            var response = await httpClient.PostAsync(Configuration.GetConnectionString("RegisterService"), httpContent);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Created)
                return true;
            else
                return false;
        }
    }


    
}
