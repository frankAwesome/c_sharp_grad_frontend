using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace c_sharp_grad_frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IConfiguration configuration;
        IToken token;
        IUserProfile userProfile;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration _configuration, IToken _token, IUserProfile _userProfile) //add userprofile here so that you can null it and ttoken
        {
            _logger = logger;
            configuration = _configuration;
            token = _token;
            userProfile = _userProfile;
        }

        public void OnGet()
        {
            userProfile.Username = null;
            userProfile.AvatarOne = null;
            userProfile.Firstname = null;
            userProfile.Lastname = null;
            userProfile.AddressOne = null;
            userProfile.AddressTwo = null;
            userProfile.Email = null;
            userProfile.Country = null;
            userProfile.Zip = null;

            userProfile.NameOnCard = null;
            userProfile.PaymentType = null;
            userProfile.CardNumber = null;
            userProfile.CVV = null;
            token.token = null;
            token.username = null;
        }
    }
}
