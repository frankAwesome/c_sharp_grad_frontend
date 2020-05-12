using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using c_sharp_grad_frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace c_sharp_grad_frontend.Helpers
{
    public class SSLHelper
    {
        public static HttpClientHandler GetSSL()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            return clientHandler; 
        }
    }
}