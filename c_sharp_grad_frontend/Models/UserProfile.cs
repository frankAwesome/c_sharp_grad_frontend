using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_grad_frontend.Models
{
    public class UserProfile:IUserProfile
    {
        public int Id { get; set; }
        public byte[] AvatarOne { get; set; }
        public byte[] AvatarTwo { get; set; }
        public byte[] AvatarThree { get; set; }
        public string Username { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public string PaymentType { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationOnCard { get; set; }

        public string CVV { get; set; }



        public string ExtraPropOne { get; set; }
        public string ExtraPropTwo { get; set; }
        public string ExtraPropThree { get; set; }
        public string ExtraPropFour { get; set; }

        public UserProfile()
        {

        }
    }
}
