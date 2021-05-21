using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Costes_ini
    {
        public int Id { get; set; }
        [Required]
        public string motivo { get; set; }
        [Required]
        public string tipo_valor { get; set; }
        [Required]
        public double valor { get; set; }



        public Costos_gastos Costos_gastos { get; set; }
        public int Costos_gastos_id { get; set; }
    }
}