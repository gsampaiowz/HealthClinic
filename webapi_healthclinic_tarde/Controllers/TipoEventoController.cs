using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Repositories;

namespace webapi_event__tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
        {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
            {
            _tipoEventoRepository = new TipoEventoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
            {
            try
                {
                _tipoEventoRepository.Cadastrar(tipoEvento);
                return StatusCode(201);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_tipoEventoRepository.Listar());
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                _tipoEventoRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
            {
            try
                {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
