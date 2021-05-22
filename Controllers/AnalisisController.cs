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
    public class AnalisisController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AnalisisController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalisisDTO>>> Get()
        {
            var analisis = await context.Analisis.ToListAsync();
            var analisisDTO = mapper.Map<List<AnalisisDTO>>(analisis);
            return analisisDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerAnalisis")]
        public async Task<ActionResult<AnalisisDTO>> Get(int id)
        {
            var analisis = await context.Analisis.FirstOrDefaultAsync(x => x.Id == id);

            if (analisis == null)
            {
                return NotFound();
            }

            var analisisDTO = mapper.Map<AnalisisDTO>(analisis);

            return analisisDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnalisisCreacionDTO autorCreacion)
        {
            var analisis = mapper.Map<Analisis>(autorCreacion);
            context.Add(analisis);
            await context.SaveChangesAsync();
            var analisisDTO = mapper.Map<AnalisisDTO>(analisis);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = analisis.Id }, analisisDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AnalisisCreacionDTO analisisActualizacion)
        {
            var analisis = mapper.Map<Analisis>(analisisActualizacion);
            analisis.Id = id;
            context.Entry(analisis).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Analisis>> Delete(int id)
        {
            var analisisid = await context.Analisis.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (analisisid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Analisis { Id = analisisid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}