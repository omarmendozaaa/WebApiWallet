using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Models.Vista
{
    public class CarteraDTO
    {
        public List<FacturaDTO> Facturas { get; set; }
        public List<ReciboDTO> Recibos { get; set; }
        public List<LetraDTO> Letras { get; set; }

    }
}