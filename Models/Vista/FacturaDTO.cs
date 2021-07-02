using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime fecha_emision { get; set; }
        [Required]
        public DateTime fecha_pago { get; set; }
        [Required]
        public double total_facturado { get; set; }
        [Required]
        public double retencion { get; set; }

        public ClienteDTO Cliente { get; set; }
        public TasaDTO Tasa { get; set; }
        public AnalisisDTO Analisis { get; set; }
        public Costos_gastosDTO Costos_gastos { get; set; }

    }
}