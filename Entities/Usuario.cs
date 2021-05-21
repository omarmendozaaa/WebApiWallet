using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWallet.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Correo { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Contrasenya { get; set; }
    

    }
}