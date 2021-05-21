using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Creacion
{
    public class ReciboCreacionDTO
    {
        [Required]
        public DateTime fecha_emision { get; set; }
        [Required]
        public DateTime fecha_pago { get; set; }
        [Required]
        public double total_recibir { get; set; }
        public double retencion { get; set; }


        public CarteraCreacionDTO Cartera { get; set; }
        public TasaCreacionDTO Tasa { get; set; }
        public AnalisisCreacionDTO Analisis { get; set; }
        public Costos_gastosCreacionDTO Costos_gastos { get; set; }

    }
}