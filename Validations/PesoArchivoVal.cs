
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApiWallet.Validations
{
    public class PesoArchivoValidacion: ValidationAttribute
    {
        private readonly int pesoMaximoEnMegaBytes;
        public PesoArchivoValidacion(int PesoMaximoEnMegaBytes)
        {
            pesoMaximoEnMegaBytes = PesoMaximoEnMegaBytes;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximoEnMegaBytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo supera los {pesoMaximoEnMegaBytes}Mb");
            }
            
            return ValidationResult.Success;
        }
    }
}