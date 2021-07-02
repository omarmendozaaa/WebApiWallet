using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Creacion
{
    public class Costes_iniCreacionDTO
    {
        [Required]
        public string motivo { get; set; }
        public double valor { get; set; }

    }
}