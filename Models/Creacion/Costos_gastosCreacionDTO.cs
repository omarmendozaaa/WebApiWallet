using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Creacion
{
    public class Costos_gastosCreacionDTO
    {
        public double total_cg_ini { get; set; }
        public double total_cg_fin { get; set; }

        public List<Costes_finCreacionDTO> Costes_fin { get; set; }
        public List<Costes_iniCreacionDTO> Costes_ini { get; set; }
    }
}