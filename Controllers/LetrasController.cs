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
    public class LetrasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LetrasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LetraDTO>>> Get()
        {
            var letras = await context.Letras.ToListAsync();
            var letrasDTO = mapper.Map<List<LetraDTO>>(letras);
            return letrasDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerLetras")]
        public async Task<ActionResult<LetraDTO>> Get(int id)
        {
            var letra = await context.Letras.FirstOrDefaultAsync(x => x.Id == id);

            if (letra == null)
            {
                return NotFound();
            }

            var letraDTO = mapper.Map<LetraDTO>(letra);

            return letraDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LetraCreacionDTO letraCreacion)
        {
            var letra = mapper.Map<Letra>(letraCreacion);
            context.Add(letra);
            await context.SaveChangesAsync();
            var letraDTO = mapper.Map<LetraDTO>(letra);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = letra.Id }, letraDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LetraCreacionDTO letraActualizacion)
        {
            var letra = mapper.Map<Letra>(letraActualizacion);
            letra.Id = id;
            context.Entry(letra).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Letra>> Delete(int id)
        {
            var letraid = await context.Letras.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (letraid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Letra { Id = letraid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}