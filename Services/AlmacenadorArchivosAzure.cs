using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace WebApiWallet.Services
{
    public class AlmacenadorArchivosAzure : IAlmacenadorArchivos
    {
        private readonly string connectionString;

        public AlmacenadorArchivosAzure(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task BorrarArchivo(string ruta, string contenedor)
        {
            if (ruta != null)
            {
                var cuenta = CloudStorageAccount.Parse(connectionString);
                var cliente = cuenta.CreateCloudBlobClient();
                var contenedorRefe = cliente.GetContainerReference(contenedor);

                var nombreBlob = Path.GetFileName(ruta);
                var blob = contenedorRefe.GetBlobReference(nombreBlob);
                await blob.DeleteIfExistsAsync();
            }
        }

        public async Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contentType)
        {
            await BorrarArchivo(ruta, contenedor);
            return await GuardarArchivo(contenido, extension, contenedor, contentType);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contentType)
        {
            var cuenta = CloudStorageAccount.Parse(connectionString);
            var cliente = cuenta.CreateCloudBlobClient();
            var contenedorRefe = cliente.GetContainerReference(contenedor);

            await contenedorRefe.CreateIfNotExistsAsync();
            await contenedorRefe.SetPermissionsAsync(new BlobContainerPermissions{
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var nombrearchivo = $"{Guid.NewGuid()}{extension}";
            var blob = contenedorRefe.GetBlockBlobReference(nombrearchivo);
            await blob.UploadFromByteArrayAsync(contenido, 0, contenido.Length);
            blob.Properties.ContentType = contentType;
            await blob.SetPropertiesAsync();
            return blob.Uri.ToString();
        }
    }
}