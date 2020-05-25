using System;

namespace c_sharp_grad_frontend.Models
{
    public class Token : IToken
    {
        public string token { get; set; }
        public string username { get; set; }

        public decimal amount { get; set; }
        public Token()
        {
        }
    }
}