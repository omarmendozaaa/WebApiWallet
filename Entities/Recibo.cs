using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Recibo
    {
        public int Id { get; set; }
        [Required]
        public DateTime fecha_emision { get; set; }
        [Required]
        public DateTime fecha_pago { get; set; }
        [Required]
        public double total_recibir { get; set; }
        public double retencion { get; set; }

        

        public Cartera Cartera { get; set; }
        public Tasa Tasa { get; set; }
        public Costos_gastos Costos_gastos { get; set; }

        [Required]
        public int CarteraId { get; set; }
        [Required]
        public int TasaId { get; set; }
        [Required]
        public int Costos_gastosId { get; set; }
    }
}