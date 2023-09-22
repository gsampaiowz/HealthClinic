using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codefirst.ViewModels;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Repositories;

namespace webapi_event__tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
            {
            try
                {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(login.Email!, login.Senha!);

                if (usuarioBuscado == null) return StatusCode(401, "Email ou senha inválidos");

                //Lógica para TOKEN
                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!.ToString()!)
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "event.webApi",
                    audience: "event.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds 
                    );

                return Ok(new
                    {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = DateTime.Now.AddMinutes(30)
                    });
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
