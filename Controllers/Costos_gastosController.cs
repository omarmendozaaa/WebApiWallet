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
    public class Costos_gastosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Costos_gastosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costos_gastosDTO>>> Get()
        {
            var costos_gastos = await context.Costos_Gastos.ToListAsync();
            var costos_gastosDTO = mapper.Map<List<Costos_gastosDTO>>(costos_gastos);
            return costos_gastosDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerCostos_gastos")]
        public async Task<ActionResult<Costos_gastosDTO>> Get(int id)
        {
            var costos_gasto = await context.Costos_Gastos.FirstOrDefaultAsync(x => x.Id == id);

            if (costos_gasto == null)
            {
                return NotFound();
            }

            var costos_gastoDTO = mapper.Map<Costos_gastosDTO>(costos_gasto);

            return costos_gastoDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Costos_gastosCreacionDTO costos_gastoCreacion)
        {
            var costos_gasto = mapper.Map<Costos_gastos>(costos_gastoCreacion);
            context.Add(costos_gasto);
            await context.SaveChangesAsync();
            var costos_gastoDTO = mapper.Map<Costos_gastosDTO>(costos_gasto);
            return new CreatedAtRouteResult("ObtenerCostos_gastos", new { id = costos_gasto.Id }, costos_gastoDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Costos_gastosCreacionDTO costos_gastoActualizacion)
        {
            var costos_gasto = mapper.Map<Costos_gastos>(costos_gastoActualizacion);
            costos_gasto.Id = id;
            context.Entry(costos_gasto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Costos_gastos>> Delete(int id)
        {
            var costos_gastoid = await context.Costos_Gastos.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (costos_gastoid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Costos_gastos { Id = costos_gastoid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}