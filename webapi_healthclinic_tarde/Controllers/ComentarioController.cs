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
    public class ComentarioController : ControllerBase
        {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController()
            {
            _comentarioRepository = new ComentarioRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_comentarioRepository.Listar());

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
                return Ok(_comentarioRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        [Authorize(Roles = "Administrador, Paciente")]
        [HttpPost]
        public IActionResult Post(Comentario comentario)
            {
            try
                {
                _comentarioRepository.Cadastrar(comentario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize (Roles = "Administrador, Paciente")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Comentario comentario)
            {
            try
                {
                comentario.IdComentario = id;
                _comentarioRepository.Atualizar(id, comentario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador, Paciente")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                _comentarioRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
