using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Cartera
    {
        public int Id { get; set; }
        public List<Factura> Facturas { get; set; }
        public List<Recibo> Recibos { get; set; }
        public List<Letra> Letras { get; set; }
    }
}