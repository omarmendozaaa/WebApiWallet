using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Costos_gastos
    {
        public int Id { get; set; }
        public double total_cg_ini { get; set; }
        public double total_cg_fin { get; set; }

        public List<Costes_fin> Costes_fin { get; set; }
        public List<Costes_ini> Costes_ini { get; set; }
    }
}