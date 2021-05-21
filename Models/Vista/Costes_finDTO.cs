using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class Costes_finDTO
    {

        [Required]
        public string motivo { get; set; }
        [Required]
        public string tipo_valor { get; set; }
        [Required]
        public double valor { get; set; }

    }
}