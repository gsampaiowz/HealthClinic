using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Repositories;

namespace webapi_event__tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
        {
        private readonly IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
            {
            _presencaEventoRepository = new PresencaEventoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
            {
            try
                {
                _presencaEventoRepository.Cadastrar(presencaEvento);
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
                return Ok(_presencaEventoRepository.Listar());
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
                return Ok(_presencaEventoRepository.BuscarPorId(id));
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
                _presencaEventoRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
            {
            try
                {
                _presencaEventoRepository.Atualizar(id, presencaEvento);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }