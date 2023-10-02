using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;
using webapi_healthclinic_tarde.Repositories;

namespace webapi_healthclinic_tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_usuarioRepository.Listar());

                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_usuarioRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
            {
            try
                {
                _usuarioRepository.Cadastrar(usuario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
            {
            try
                {
                usuario.IdUsuario = id;
                _usuarioRepository.Atualizar(id, usuario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                _usuarioRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
