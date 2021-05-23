using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWallet.Validations;

namespace WebApiWallet.Models.Vista
{
    public class EmpresaDTO
    {
        public string ruc { get; set; }
        [Required]
        public string razonSocial { get; set; }
        public string estado { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string Logo { get; set; }
        
        //por ver logo
        public CarteraDTO Cartera { get; set; }
        public int CarteraId { get; set; }
    }
}