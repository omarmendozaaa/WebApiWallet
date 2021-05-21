using System;

namespace WebApiWallet.Models
{
    public class UserToke
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}