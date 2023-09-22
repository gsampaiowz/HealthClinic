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
    public class EventoController : ControllerBase
        {
        private readonly IEventoRepository _eventoRepository;

        public EventoController()
            {
            _eventoRepository = new EventoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Evento evento)
            {
            try
                {
                _eventoRepository.Cadastrar(evento);
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
                return Ok(_eventoRepository.Listar());
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
                return Ok(_eventoRepository.BuscarPorId(id));
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
                _eventoRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Evento evento)
            {
            try
                {
                _eventoRepository.Atualizar(id, evento);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize]
        [HttpGet("Comentarios")]
        public IActionResult GetComentarios(Guid id)
            {
            try
                {
                return Ok(_eventoRepository.ListarComentariosEvento(id));
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
