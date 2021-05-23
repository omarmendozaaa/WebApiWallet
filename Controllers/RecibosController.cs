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
    public class RecibosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RecibosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReciboDTO>>> Get()
        {
            var recibos = await context.Recibos.ToListAsync();
            var recibosDTO = mapper.Map<List<ReciboDTO>>(recibos);
            return recibosDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerRecibos")]
        public async Task<ActionResult<ReciboDTO>> Get(int id)
        {
            var recibo = await context.Recibos.FirstOrDefaultAsync(x => x.Id == id);

            if (recibo == null)
            {
                return NotFound();
            }

            var reciboDTO = mapper.Map<ReciboDTO>(recibo);

            return reciboDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReciboCreacionDTO reciboCreacion)
        {
            var recibo = mapper.Map<Recibo>(reciboCreacion);
            context.Add(recibo);
            await context.SaveChangesAsync();
            var reciboDTO = mapper.Map<ReciboDTO>(recibo);
            return new CreatedAtRouteResult("ObtenerRecibos", new { id = recibo.Id }, reciboDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReciboCreacionDTO reciboActualizacion)
        {
            var recibo = mapper.Map<Recibo>(reciboActualizacion);
            recibo.Id = id;
            context.Entry(recibo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recibo>> Delete(int id)
        {
            var reciboid = await context.Recibos.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (reciboid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Recibo { Id = reciboid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}