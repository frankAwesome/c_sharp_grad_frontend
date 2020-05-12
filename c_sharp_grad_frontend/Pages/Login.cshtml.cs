using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using c_sharp_grad_frontend.Helpers;
using c_sharp_grad_frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace c_sharp_grad_frontend.Pages
{
    public class LoginModel : PageModel
    {
        public LoginModel(IConfiguration configuration, IToken _token)
        {
            Configuration = configuration;
            token = _token;
        }
        public IConfiguration Configuration { get; }
        public IToken token { get; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //the Configuration allow us to get connection strings from the appsetting.json config file
            try
            {
                var helper = new LoginHelper(Configuration, token);
                var model = new User();
                model.username = Request.Form["username"];
                model.password = Request.Form["password"];

                if (await helper.CallAuthService(model))
                    return RedirectToPage("/Donate");
                else
                    return RedirectToPage("/AuthFailed");
            }
            catch (Exception)
            {
                return RedirectToPage("/AuthFailed");
            }     
        }
    }
}
