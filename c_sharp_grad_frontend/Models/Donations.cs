using System;

namespace c_sharp_grad_frontend.Models
{
    public class Donations
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int OrganizationId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

    }
}