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
    public class ProfileViewModel : PageModel
    {
        IToken token;
        public IConfiguration Configuration { get; }
        public IUserProfile userProfile;

        public string image;

        public ProfileViewModel(IConfiguration _configuration, IToken _token, IUserProfile _userProfile)
        {
            this.token = _token;
            this.Configuration = _configuration;
            this.userProfile = _userProfile;
        }


        public void OnGet()
        {
            image = Convert.ToBase64String(userProfile.AvatarOne);

        }
    }
}