using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class LetraDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime fecha_giro { get; set; }
        [Required]
        public DateTime fecha_vencimiento { get; set; }
        [Required]
        public double valor_Nom { get; set; }
        public double retencion { get; set; }


        public ClienteDTO Cliente { get; set; }
        public TasaDTO Tasa { get; set; }
        public AnalisisDTO Analisis { get; set; }
        public Costos_gastosDTO Costos_gastos { get; set; }

    }
}