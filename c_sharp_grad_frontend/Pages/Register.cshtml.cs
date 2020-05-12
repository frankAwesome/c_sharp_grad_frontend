using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Helpers;
using c_sharp_grad_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace c_sharp_grad_frontend.Pages
{
    public class RegisterModel : PageModel
    {
        public RegisterModel(IConfiguration configuration, IToken _token)
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
                var helper = new RegisterHelper(Configuration);
                var model = new User();
                model.username = Request.Form["username"];
                model.password = Request.Form["password"];

                if (await helper.CallAuthService(model))
                    return RedirectToPage("/RegisterSuccess");
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