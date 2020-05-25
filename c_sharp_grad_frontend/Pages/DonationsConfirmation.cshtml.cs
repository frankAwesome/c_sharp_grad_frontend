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
    public class DonationsConfirmationModel : PageModel
    {
        IToken token;
        IConfiguration configuration;
        IUserProfile userProfile;

        public string amount;

        public DonationsConfirmationModel(IToken _token, IConfiguration _configuration, IUserProfile _userProfile)
        {
            token = _token;
            configuration = _configuration;
            userProfile = _userProfile;
            amount = token.amount.ToString();
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var helper = new DonationHelper(configuration, token);
            await helper.PostDonation(token.amount);

            return RedirectToPage("/Donations");
        }
    }
}