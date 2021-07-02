using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWallet.Validations;

namespace WebApiWallet.Models.Vista
{
    public class ClienteDTO
    {
        public string Id { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string contacto { get; set; }
        public string direccion { get; set; }
        public string distrito { get; set; }

    }
}