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
    public class DonationsManagerModel : PageModel
    {
        IToken token;
        IConfiguration configuration;
        IUserProfile userProfile;
        public string image;

        public List<Donations> donations;
        public DonationsManagerModel(IToken _token, IConfiguration _configuration, IUserProfile _userProfile)
        {
            token = _token;
            configuration = _configuration;
            userProfile = _userProfile;

        }

        public async Task OnGet()
        {
            var helper = new DonationHelper(configuration, token);
            donations = await helper.GetDonationsForUser(token.username);
            image = Convert.ToBase64String(userProfile.AvatarOne);
        }

        public async Task OnPost()
        {
            decimal amount = Convert.ToDecimal(Request.Form["amount"]);
            //the Configuration allow us to get connection strings from the appsetting.json config file
            var helper = new DonationHelper(configuration, token);
            await helper.PostDonation(amount);
        }
    }
}