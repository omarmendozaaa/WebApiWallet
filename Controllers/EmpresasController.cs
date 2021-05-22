using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWallet.Contexts;
using WebApiWallet.Entities;
using WebApiWallet.Models.Creacion;
using WebApiWallet.Models.Vista;

namespace WebApiWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmpresasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> Get()
        {
            var empresas = await context.Empresas.ToListAsync();
            var empresasDTO = mapper.Map<List<EmpresaDTO>>(empresas);
            return empresasDTO;
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
            var empresa = mapper.Map<Empresa>(empresaCreacion);
            context.Add(empresa);
            await context.SaveChangesAsync();
            var empresaDTO = mapper.Map<EmpresaDTO>(empresa);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = empresa.Id }, empresaDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmpresaCreacionDTO empresaActualizacion)
        {
            var empresa = mapper.Map<Empresa>(empresaActualizacion);
            empresa.Id = id;
            context.Entry(empresa).State = EntityState.Modified;
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

            context.Remove(new Empresa { Id = empresaid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}