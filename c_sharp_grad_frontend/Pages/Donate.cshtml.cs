using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

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

        public void OnGet()
        {

        }
    }
}