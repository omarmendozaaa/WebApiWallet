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
    public class CarterasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CarterasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarteraDTO>>> Get()
        {
            var carteras = await context.Carteras.ToListAsync();
            var carterasDTO = mapper.Map<List<CarteraDTO>>(carteras);
            return carterasDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerCarteras")]
        public async Task<ActionResult<CarteraDTO>> Get(int id)
        {
            var cartera = await context.Carteras.FirstOrDefaultAsync(x => x.Id == id);

            if (cartera == null)
            {
                return NotFound();
            }

            var carteraDTO = mapper.Map<CarteraDTO>(cartera);

            return carteraDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarteraCreacionDTO carteraCreacion)
        {
            var cartera = mapper.Map<Cartera>(carteraCreacion);
            context.Add(cartera);
            await context.SaveChangesAsync();
            var carteraDTO = mapper.Map<CarteraDTO>(cartera);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = cartera.Id }, carteraDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CarteraCreacionDTO carteraActualizacion)
        {
            var cartera = mapper.Map<Cartera>(carteraActualizacion);
            cartera.Id = id;
            context.Entry(cartera).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cartera>> Delete(int id)
        {
            var carteraid = await context.Carteras.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (carteraid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Cartera { Id = carteraid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}