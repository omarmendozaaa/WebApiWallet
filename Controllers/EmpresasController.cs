using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWallet.Contexts;
using WebApiWallet.Entities;
using WebApiWallet.Models;
using WebApiWallet.Models.Creacion;
using WebApiWallet.Models.Vista;
using WebApiWallet.Services;

namespace WebApiWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "empresas";

        public EmpresasController(ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> Get()
        {
            var empresas = await context.Empresas.ToListAsync();
            var empresasDTO = mapper.Map<List<EmpresaDTO>>(empresas);
            return empresasDTO;
        }
        [HttpGet("byuser")]
        public async Task<ActionResult<EmpresaDTO>> GetByUser()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await userManager.FindByEmailAsync(email);
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.UsuarioId == user.Id);
            var empresaDTO = mapper.Map<EmpresaDTO>(empresa);
            return empresaDTO;
        }
        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerEmpresas")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            var empresaDTO = mapper.Map<EmpresaDTO>(empresa);

            return empresaDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmpresaCreacionDTO empresaCreacion)
        {
            if (User.Identity.IsAuthenticated)
            {
                var carteraCreacion = new CarteraCreacionDTO();
                var cartera = mapper.Map<Cartera>(carteraCreacion);
                context.Add(cartera);
                await context.SaveChangesAsync();
                var empresa = mapper.Map<Empresa>(empresaCreacion);
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await userManager.FindByEmailAsync(email);
                empresa.UsuarioId = user.Id.ToString();
                if (empresaCreacion.Logo != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await empresaCreacion.Logo.CopyToAsync(memoryStream);
                        var contenido = memoryStream.ToArray();
                        var extension = Path.GetExtension(empresaCreacion.Logo.FileName);
                        empresa.Logo = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor, empresaCreacion.Logo.ContentType);
                    }
                }
                empresa.CarteraId = cartera.Id;
                context.Add(empresa);
                await context.SaveChangesAsync();
                var empresaDTO = mapper.Map<EmpresaDTO>(empresa);
                return new CreatedAtRouteResult("ObtenerEmpresas", new { id = empresa.Id }, empresaDTO);
            }
            else
            {
                return BadRequest("El inicio  de sesión expiró");
            }

        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmpresaCreacionDTO empresaActualizacion)
        {
            var empresaDb = await context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            if (empresaDb == null)
            {
                return NotFound();
            }
            empresaDb = mapper.Map(empresaActualizacion, empresaDb);
            if (empresaActualizacion.Logo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await empresaActualizacion.Logo.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(empresaActualizacion.Logo.FileName);
                    empresaDb.Logo = await almacenadorArchivos.EditarArchivo(contenido, extension, contenedor, empresaDb.Logo, empresaActualizacion.Logo.ContentType);
                }
            }
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> Delete(int id)
        {
            var empresaid = await context.Empresas.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (empresaid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Empresa { Id = empresaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}