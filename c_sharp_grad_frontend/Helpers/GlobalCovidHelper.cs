using c_sharp_grad_frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace c_sharp_grad_frontend.Helpers
{
    public class GlobalCovidHelper
    {
        IConfiguration configuration;
        IToken token;
        IGlobalCovid global;

        public GlobalCovidHelper(IConfiguration _configuration, IToken _token, IGlobalCovid _global)
        {
            configuration = _configuration;
            token = _token;
            global = _global;
        }

        public async Task GetCovidInfo()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(configuration.GetConnectionString("GetGlobalCovidService"));            
            string apiResponse = await response.Content.ReadAsStringAsync();

            if (apiResponse == "You have reached maximum request limit.")
            {
                response = await httpClient.GetAsync(configuration.GetConnectionString("GetGlobalCovidService"));
                apiResponse = await response.Content.ReadAsStringAsync();

                if (apiResponse == "You have reached maximum request limit.")
                {
                    global.NewConfirmed = 0;
                    global.NewDeaths = 0;
                    global.NewRecovered = 0;
                    global.TotalDeaths = 0;
                    global.TotalRecovered = 0;
                    global.TotalConfirmed = 0;
                }         
            }

            JObject json = JObject.Parse(apiResponse);
            var val = json["Global"];
            var _global = JsonConvert.DeserializeObject<GlobalCovid>(JsonConvert.SerializeObject(val));
            global.NewConfirmed = _global.NewConfirmed;
            global.NewDeaths = _global.NewDeaths;
            global.NewRecovered = _global.NewRecovered;
            global.TotalDeaths = _global.TotalDeaths;
            global.TotalRecovered = _global.TotalRecovered;
            global.TotalConfirmed = _global.TotalConfirmed;           
        }
    }
}
