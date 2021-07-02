using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApiWallet.Entities;

namespace WebApiWallet.Models.Creacion
{
    public class FacturaCreacionDTO
    {
        [Required]
        public DateTime fecha_emision { get; set; }
        [Required]
        public DateTime fecha_pago { get; set; }
        [Required]
        public double total_facturado { get; set; }
        [Required]
        public double retencion { get; set; }
        public int ClienteId { get; set; }



        public int CarteraId { get; set; }
        public TasaCreacionDTO Tasa { get; set; }
        public AnalisisCreacionDTO Analisis { get; set; }
        public Costos_gastosCreacionDTO Costos_gastos { get; set; }

    }
}