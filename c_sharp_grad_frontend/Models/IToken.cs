using System;

namespace c_sharp_grad_frontend.Models
{
    public interface IToken
    {
        public string token { get; set; }
        public string username { get; set; }
    }
}