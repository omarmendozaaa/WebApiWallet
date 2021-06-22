using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Creacion
{
    public class LetraCreacionDTO
    {
        [Required]
        public DateTime fecha_giro { get; set; }
        [Required]
        public DateTime fecha_vencimiento { get; set; }
        [Required]
        public double valor_Nom { get; set; }
        public double retencion { get; set; }
        public int ClienteId { get; set; }

        public CarteraCreacionDTO Cartera { get; set; }
        public TasaCreacionDTO Tasa { get; set; }
        public AnalisisCreacionDTO Analisis { get; set; }
        public Costos_gastosCreacionDTO Costos_gastos { get; set; }

    }
}