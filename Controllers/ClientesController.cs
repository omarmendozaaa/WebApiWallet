using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWallet.Contexts;
using WebApiWallet.Entities;
using WebApiWallet.Models.Creacion;
using WebApiWallet.Models.Vista;
using Microsoft.AspNetCore.Identity;
using WebApiWallet.Models;

namespace WebApiWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientesController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await context.Clientes.ToListAsync();
            var clientesDTO = mapper.Map<List<ClienteDTO>>(clientes);
            return clientesDTO;
        }
        [HttpGet("byuser")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetByUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await userManager.FindByEmailAsync(email);
                var clientes = await context.Clientes.Where(x => x.UsuarioId == user.Id).ToListAsync();
                var clientesDTO = mapper.Map<List<ClienteDTO>>(clientes);
                return clientesDTO;
            }
            else
            {
                return BadRequest("No permitido");
            }
        }
        // GET api/autores/5 
        [HttpGet("{id}", Name = "ObtenerClientes")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDTO = mapper.Map<ClienteDTO>(cliente);

            return clienteDTO;
        }
        // POST api/autores
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacion)
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await userManager.FindByEmailAsync(email);
                var cliente = mapper.Map<Cliente>(clienteCreacion);
                cliente.UsuarioId = user.Id;
                context.Add(cliente);
                await context.SaveChangesAsync();
                var clienteDTO = mapper.Map<ClienteDTO>(cliente);
                return new CreatedAtRouteResult("ObtenerClientes", new { id = cliente.Id }, clienteDTO);
            }
            else
            {
                return BadRequest("No permitido");
            }

        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteCreacionDTO clienteActualizacion)
        {
            var cliente = mapper.Map<Cliente>(clienteActualizacion);
            cliente.Id = id;
            context.Entry(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var clienteid = await context.Clientes.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (clienteid == default(int))
            {
                return NotFound();
            }

            context.Remove(new Cliente { Id = clienteid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}