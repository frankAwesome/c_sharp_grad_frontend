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
    public class AdminHomeModel : PageModel
    {
        IToken token;
        IConfiguration configuration;
        public AdminHomeModel(IToken _token, IConfiguration _configuration)
        {
            token = _token;
            configuration = _configuration;

        }
        public async Task OnGet()
        {
            var helper = new DonationHelper(configuration, token);
            var allUserDonation = helper.GetAllDonations();


        }
    }
}