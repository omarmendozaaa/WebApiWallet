using System;
using Microsoft.AspNetCore.Identity;

namespace WebApiWallet.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}