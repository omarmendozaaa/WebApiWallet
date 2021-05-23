using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Costes_finsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Costes_finsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costes_finDTO>>> Get()
        {
            var coste_fins = await context.Costes_fins.ToListAsync();
            var coste_finsDTO = mapper.Map<List<Costes_finDTO>>(coste_fins);
            return coste_finsDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerCostes_fins")]
        public async Task<ActionResult<Costes_finDTO>> Get(int id)
        {
            var coste_fin = await context.Costes_fins.FirstOrDefaultAsync(x => x.Id == id);

            if (coste_fin == null)
            {
                return NotFound();
            }

            var coste_finDTO = mapper.Map<Costes_finDTO>(coste_fin);

            return coste_finDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Costes_finCreacionDTO coste_finCreacion)
        {
            var coste_fin = mapper.Map<Costes_fin>(coste_finCreacion);
            context.Add(coste_fin);
            await context.SaveChangesAsync();
            var coste_finDTO = mapper.Map<Costes_finDTO>(coste_fin);
            return new CreatedAtRouteResult("ObtenerCostes_fins", new { id = coste_fin.Id }, coste_finDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Costes_finCreacionDTO coste_finActualizacion)
        {
            var coste_fin = mapper.Map<Costes_fin>(coste_finActualizacion);
            coste_fin.Id = id;
            context.Entry(coste_fin).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Costes_fin>> Delete(int id)
        {
            var coste_finid = await context.Costes_fins.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (coste_finid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Costes_fin { Id = coste_finid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}