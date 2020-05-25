using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace c_sharp_grad_frontend.Pages
{
    public class DonateModel : PageModel
    {
        public DonateModel(IConfiguration configuration, IToken _token)
        {
            Configuration = configuration;
            token = _token;
        }
        public IConfiguration Configuration { get; }
        public IToken token { get; }

        public GlobalCovid global { get; set; }


        public async Task<bool> GetCovidInfo()
        {
            global = new GlobalCovid();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.covid19api.com/summary"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse == "You have reached maximum request limit.")
                    {
                        global.NewConfirmed = 0;
                        global.NewDeaths = 0;
                        global.NewRecovered = 0;
                        global.TotalDeaths = 0;
                        global.TotalRecovered = 0;
                        global.TotalConfirmed = 0;
                        return false;

                    }
                    JObject json = JObject.Parse(apiResponse);
                    var val = json["Global"];
                    global = JsonConvert.DeserializeObject<GlobalCovid>(JsonConvert.SerializeObject(val));
                }
            }
            return true;
        }

        public async Task OnGetAsync()
        {
            var val = await GetCovidInfo();
        }
    }
}