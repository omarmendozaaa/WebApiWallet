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
    public class TasasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TasasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasaDTO>>> Get()
        {
            var tasas = await context.Tasas.ToListAsync();
            var tasasDTO = mapper.Map<List<TasaDTO>>(tasas);
            return tasasDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerTasas")]
        public async Task<ActionResult<TasaDTO>> Get(int id)
        {
            var tasa = await context.Tasas.FirstOrDefaultAsync(x => x.Id == id);

            if (tasa == null)
            {
                return NotFound();
            }

            var tasaDTO = mapper.Map<TasaDTO>(tasa);

            return tasaDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TasaCreacionDTO tasaCreacion)
        {
            var tasa = mapper.Map<Tasa>(tasaCreacion);
            context.Add(tasa);
            await context.SaveChangesAsync();
            var tasaDTO = mapper.Map<TasaDTO>(tasa);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = tasa.Id }, tasaDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TasaCreacionDTO tasaActualizacion)
        {
            var tasa = mapper.Map<Tasa>(tasaActualizacion);
            tasa.Id = id;
            context.Entry(tasa).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasa>> Delete(int id)
        {
            var tasaid = await context.Tasas.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (tasaid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Tasa { Id = tasaid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}