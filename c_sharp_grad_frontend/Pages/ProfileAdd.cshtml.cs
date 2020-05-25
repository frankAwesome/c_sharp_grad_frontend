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
using static System.Net.Mime.MediaTypeNames;

namespace c_sharp_grad_frontend.Pages
{
    public class ProfileAddModel : PageModel
    {
        IUserProfile userProfile;
        IToken token;
        public IConfiguration Configuration { get; }

        public ProfileAddModel(IConfiguration _configuration, IToken _token, IUserProfile _userProfile)
        {
            userProfile = _userProfile;
            token = _token;
            Configuration = _configuration;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(IFormFile avatar)
        {
            var imageByte = avatar;
            BinaryReader br = new BinaryReader(imageByte.OpenReadStream());

            userProfile.AvatarOne = br.ReadBytes((int)imageByte.OpenReadStream().Length);
            userProfile.Username = token.username;
            userProfile.Firstname = Request.Form["firstname"];
            userProfile.Lastname = Request.Form["lastname"];
            userProfile.Email = Request.Form["email"];

            userProfile.AddressOne = Request.Form["addressone"];
            userProfile.AddressTwo = Request.Form["addresstwo"];
            userProfile.Zip = Request.Form["zip"];

            userProfile.NameOnCard = Request.Form["nameoncard"];
            userProfile.CVV = Request.Form["cvv"];
            userProfile.CardNumber = Request.Form["cardnumber"];

            userProfile.ExpirationOnCard = DateTime.Parse(Request.Form["expdate"]);
            userProfile.PaymentType = Request.Form["paymenttype"];

            var helper = new UserProfileHelper(Configuration, token);

            if (await helper.PostProfile(userProfile))
                return RedirectToPage("/Profile");
            else
                return RedirectToPage("/Error");
        }
    }
}