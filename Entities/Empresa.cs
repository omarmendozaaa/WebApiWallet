using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWallet.Validations;

namespace WebApiWallet.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string ruc { get; set; }
        [Required]
        public string razonSocial { get; set; }
        public string estado { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string Logo { get; set; }

        
        public Cartera Cartera { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int CarteraId { get; set; }
    }
}