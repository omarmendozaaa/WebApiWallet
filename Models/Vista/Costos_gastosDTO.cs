using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class Costos_gastosDTO
    {
        public double total_cg_ini { get; set; }
        public double total_cg_fin { get; set; }

        public List<Costes_finDTO> Costes_fin { get; set; }
        public List<Costes_iniDTO> Costes_ini { get; set; }
    }
}