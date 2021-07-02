using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiWallet.Contexts;
using WebApiWallet.Models;
using WebApiWallet.Models.Vista;

namespace WebApiWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasControllers : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;

        public CuentasControllers(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManger = userManager;
            this.context = context;
            _signInManager = signInManager;
            _configuration = configuration;
            this.mapper = mapper;
        }
        [HttpGet("getuser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ApplicationUserDTO>> GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await _userManger.FindByEmailAsync(email);
                var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.UsuarioId == user.Id);
                if (empresa == null)
                {
                    var userDTO = mapper.Map<ApplicationUserDTO>(user);
                    return userDTO;
                }
                else
                {
                    var userDTOwithempres = mapper.Map<ApplicationUserDTO>(user);
                    userDTOwithempres.EmpresaId = empresa.Id;
                    userDTOwithempres.CarteraId = empresa.CarteraId;
                    return userDTOwithempres;
                }

            }
            else
            {
                return BadRequest("El usuario no está autenticado");
            }

        }
        [HttpPost("Singin")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            var result = await _userManger.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                string userid = user.Id;
                return BuildToken(model, userid);
            }
            else
            {
                return BadRequest("Ya existe una cuenta con este correo electrónico");
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfoLogin userInfologin)
        {
            var userInfo = new UserInfo();
            userInfo.Email = userInfologin.Email;
            userInfo.Password = userInfologin.Password;
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManger.FindByEmailAsync(userInfo.Email);
                string userid = user.Id;
                return BuildToken(userInfo, userid);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "El usuario o contraseña es incorrecto");
                return BadRequest(ModelState);
            }
        }
        private UserToken BuildToken(UserInfo userInfo, string userid)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.NameId, userid),
                new Claim("gaaaa", "pichula"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Expiración

            var expiration = DateTime.UtcNow.AddHours(2);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}