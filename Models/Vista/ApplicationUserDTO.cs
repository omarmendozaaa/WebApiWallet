using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebApiWallet.Entities;

namespace WebApiWallet.Models.Vista
{
    public class ApplicationUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmpresaId { get; set; }
        public int CarteraId { get; set; }
    }
}