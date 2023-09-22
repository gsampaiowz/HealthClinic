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
    public class ComentarioEventoController : ControllerBase
        {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController()
            {
            _comentarioEventoRepository = new ComentarioEventoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
            {
            try
                {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);
                return StatusCode(201);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_comentarioEventoRepository.Listar());
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        [Authorize (Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
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
                _comentarioEventoRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ComentarioEvento comentarioEvento)
            {
            try
                {
                _comentarioEventoRepository.Atualizar(id, comentarioEvento);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
