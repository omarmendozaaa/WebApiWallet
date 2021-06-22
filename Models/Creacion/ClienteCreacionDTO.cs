using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWallet.Models;
using WebApiWallet.Validations;

namespace WebApiWallet.Models.Creacion
{
    public class ClienteCreacionDTO
    {
        public string ruc { get; set; }
        [Required]
        public string razonSocial { get; set; }
        [Phone]
        public string contacto { get; set; }

    }
}