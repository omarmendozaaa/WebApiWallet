using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class TasaDTO
    {
        [Required]
        public int dias_ano { get; set; }
        [Required]
        public int plazo_tasa { get; set; }
        [Required]
        public float tasa_efectiva { get; set; }
        public DateTime fecha_descuento { get; set; }
    }
}