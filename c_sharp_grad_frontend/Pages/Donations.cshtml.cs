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
    public class DonationsModel : PageModel
    {
        IToken token;
        IConfiguration configuration;
        IUserProfile userProfile;

        public List<Donations> donations;
        public DonationsModel(IToken _token, IConfiguration _configuration, IUserProfile _userProfile)
        {
            token = _token;
            configuration = _configuration;
            userProfile = _userProfile;
        }
        
        public async Task<IActionResult> OnGet()
        {
            var helper = new UserProfileHelper(this.configuration, this.token);
            if (this.userProfile.Firstname == null)
            {
                var response = await helper.GetProfile(token.username);
                if (response != null)
                {
                    userProfile.Username = response.Username;
                    userProfile.AvatarOne = response.AvatarOne;
                    userProfile.Firstname = response.Firstname;
                    userProfile.Lastname = response.Lastname;
                    userProfile.AddressOne = response.AddressOne;
                    userProfile.AddressTwo = response.AddressTwo;
                    userProfile.Email = response.Email;
                    userProfile.Country = response.Country;
                    userProfile.Zip = response.Zip;

                    userProfile.NameOnCard = response.NameOnCard;
                    userProfile.PaymentType = response.PaymentType;
                    userProfile.ExpirationOnCard = response.ExpirationOnCard;
                    userProfile.CardNumber = response.CardNumber;
                    userProfile.CVV = response.CVV;
                }


                if (response != null)
                    return RedirectToPage("DonationsManager");
                else
                    return RedirectToPage("DonationsCreate");
            }
            else
                return RedirectToPage("DonationsManager");

        }
    }
}