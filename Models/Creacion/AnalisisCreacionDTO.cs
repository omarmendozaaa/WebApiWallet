using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Creacion
{
    public class AnalisisCreacionDTO
    {
        public double te_anual { get; set; }
        public int num_dias { get; set; }
        public double tefectiva { get; set; }
        public double tasadescontada { get; set; }
        public float descuento { get; set; }
        public float retencion { get; set; }
        public float costesiniciales { get; set; }
        public float valorneto { get; set; }
        public float valortotalrecibir { get; set; }
        public float costesfinales { get; set; }
        public float valortotalentregar { get; set; }
        public double tce_anual { get; set; }
    }
}