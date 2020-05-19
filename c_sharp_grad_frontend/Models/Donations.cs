using System;

namespace c_sharp_grad_frontend.Models
{
    public class Donations
    {
        public string Username { get; set; }
        public decimal Amount { get; set; }
        public int OrganizationId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        public string ExtraOne { get; set; }
        public string ExtraTwo { get; set; }
        public string ExtraThree { get; set; }

    }
}