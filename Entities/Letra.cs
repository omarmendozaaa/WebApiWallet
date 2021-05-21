using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Letra
    {
        public int Id { get; set; }
        [Required]
        public DateTime fecha_giro { get; set; }
        [Required]
        public DateTime fecha_vencimiento { get; set; }
        [Required]
        public double valor_Nom { get; set; }
        public double retencion { get; set; }

        

        public Cartera Cartera { get; set; }
        public Tasa Tasa { get; set; }
        public Analisis Analisis { get; set; }
        public Costos_gastos Costos_gastos { get; set; }

        [Required]
        public int CarteraId { get; set; }
        [Required]
        public int TasaId { get; set; }
        [Required]
        public int AnalisisId { get; set; }
        [Required]
        public int Costos_gastosId { get; set; }
    }
}