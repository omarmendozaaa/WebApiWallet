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
    public class Costes_inisController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Costes_inisController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costes_iniDTO>>> Get()
        {
            var coste_inis = await context.Costes_inis.ToListAsync();
            var coste_inisDTO = mapper.Map<List<Costes_iniDTO>>(coste_inis);
            return coste_inisDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerCostes_inis")]
        public async Task<ActionResult<Costes_iniDTO>> Get(int id)
        {
            var coste_ini = await context.Costes_inis.FirstOrDefaultAsync(x => x.Id == id);

            if (coste_ini == null)
            {
                return NotFound();
            }

            var coste_iniDTO = mapper.Map<Costes_iniDTO>(coste_ini);

            return coste_iniDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Costes_iniCreacionDTO coste_iniCreacion)
        {
            var coste_ini = mapper.Map<Costes_ini>(coste_iniCreacion);
            context.Add(coste_ini);
            await context.SaveChangesAsync();
            var coste_iniDTO = mapper.Map<Costes_iniDTO>(coste_ini);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = coste_ini.Id }, coste_iniDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Costes_iniCreacionDTO coste_iniActualizacion)
        {
            var coste_ini = mapper.Map<Costes_ini>(coste_iniActualizacion);
            coste_ini.Id = id;
            context.Entry(coste_ini).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Costes_ini>> Delete(int id)
        {
            var coste_iniid = await context.Costes_inis.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (coste_iniid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Costes_ini { Id = coste_iniid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}