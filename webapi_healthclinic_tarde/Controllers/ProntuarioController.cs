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
    public class ProntuarioController : ControllerBase
        {
        private readonly IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
            {
            _prontuarioRepository = new ProntuarioRepository();
            }

        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_prontuarioRepository.Listar());

                }
            catch (Exception e)
                {

                return BadRequest(e); 
                }
            }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_prontuarioRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPost]
        public IActionResult Post(Prontuario prontuario)
            {
            try
                {
                _prontuarioRepository.Cadastrar(prontuario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Prontuario prontuario)
            {
            try
                {
                prontuario.IdProntuario = id;
                _prontuarioRepository.Atualizar(id, prontuario);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                _prontuarioRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
