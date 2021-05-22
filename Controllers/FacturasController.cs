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
    public class FacturasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FacturasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDTO>>> Get()
        {
            var facturas = await context.Facturas.ToListAsync();
            var facturasDTO = mapper.Map<List<FacturaDTO>>(facturas);
            return facturasDTO;
        }

        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerFacturas")]
        public async Task<ActionResult<FacturaDTO>> Get(int id)
        {
            var factura = await context.Facturas.FirstOrDefaultAsync(x => x.Id == id);

            if (factura == null)
            {
                return NotFound();
            }

            var facturaDTO = mapper.Map<FacturaDTO>(factura);

            return facturaDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaCreacionDTO facturaCreacion)
        {
            var factura = mapper.Map<Factura>(facturaCreacion);
            context.Add(factura);
            await context.SaveChangesAsync();
            var facturaDTO = mapper.Map<FacturaDTO>(factura);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = factura.Id }, facturaDTO);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaCreacionDTO facturaActualizacion)
        {
            var factura = mapper.Map<Factura>(facturaActualizacion);
            factura.Id = id;
            context.Entry(factura).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> Delete(int id)
        {
            var facturaid = await context.Facturas.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (facturaid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Factura { Id = facturaid});
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}