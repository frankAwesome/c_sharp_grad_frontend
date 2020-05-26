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
using c_sharp_grad_frontend.Helpers;

namespace c_sharp_grad_frontend.Pages
{
    public class DonateModel : PageModel
    {
        public DonateModel(IConfiguration configuration, IToken _token, IGlobalCovid _global)
        {
            Configuration = configuration;
            token = _token;
            global = _global;
        }
        public IConfiguration Configuration { get; }
        public IToken token { get; }
        public IGlobalCovid global { get; set; }

        public async Task OnGetAsync()
        {
            var helper = new GlobalCovidHelper(Configuration, token, global);
            if (global.TotalDeaths == 0)
                await helper.GetCovidInfo();
        }
    }
}