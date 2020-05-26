using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Helpers;
using c_sharp_grad_frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace c_sharp_grad_frontend.Pages
{
    public class ProfileEditModel : PageModel
    {
        public IUserProfile userProfile;
        IToken token;
        IConfiguration configuration;

        public string image;

        public ProfileEditModel(IConfiguration _configuration, IToken _token, IUserProfile _userProfile)
        {
            configuration = _configuration;
            token = _token;
            userProfile = _userProfile;
        }

        public void OnGet()
        {
            image = Convert.ToBase64String(userProfile.AvatarOne);
        }

        public async Task<IActionResult> OnPost(IFormFile avatar)
        {
            if (avatar != null)
            { 
                BinaryReader br = new BinaryReader(avatar.OpenReadStream());
                userProfile.AvatarOne = br.ReadBytes((int)avatar.OpenReadStream().Length) ?? userProfile.AvatarOne;
            }
            
            userProfile.Username = token.username ?? userProfile.Username;
            userProfile.Firstname = (Request.Form["firstname"]).ToString() ?? userProfile.Firstname;
            userProfile.Lastname = (Request.Form["lastname"]).ToString() ?? userProfile.Lastname;
            userProfile.Email = (Request.Form["email"]).ToString() ?? userProfile.Email;

            userProfile.AddressOne = (Request.Form["addressone"]).ToString() ?? userProfile.AddressOne;
            userProfile.AddressTwo = (Request.Form["addresstwo"]).ToString() ?? userProfile.AddressTwo;
            userProfile.Zip = (Request.Form["zip"]).ToString() ?? userProfile.Zip;

            userProfile.NameOnCard = (Request.Form["nameoncard"]).ToString() ?? userProfile.NameOnCard;
            userProfile.CVV = (Request.Form["cvv"]).ToString() ?? userProfile.CVV;
            userProfile.CardNumber = (Request.Form["cardnumber"]).ToString() ?? userProfile.CardNumber;

            userProfile.ExpirationOnCard = DateTime.Parse(Request.Form["expdate"]);
            userProfile.PaymentType = Request.Form["paymenttype"];

            var helper = new UserProfileHelper(configuration, token);

            if (await helper.EditProfile(userProfile))
                return RedirectToPage("/Profile");
            else
                return RedirectToPage("/Error");
        }
    }
}