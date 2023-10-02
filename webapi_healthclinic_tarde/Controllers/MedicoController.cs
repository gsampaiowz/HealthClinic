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
    public class MedicoController : ControllerBase
        {
        private readonly MedicoRepository _medicoRepository;

        public MedicoController()
            {
            _medicoRepository = new MedicoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_medicoRepository.Listar());

                }
            catch (Exception e)
                {

                return BadRequest(e); 
                }
            }

        [Authorize(Roles = "Administrador, Paciente, Médico")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_medicoRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Medico medico)
            {
            try
                {
                _medicoRepository.Cadastrar(medico);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Medico medico)
            {
            try
                {
                medico.IdMedico = id;
                _medicoRepository.Atualizar(id, medico);
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
                _medicoRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpGet("consultas/{id}")]
        public IActionResult MedicoConsultas(Guid id)
            {
            try
                {
                return Ok(_medicoRepository.MedicoConsultas(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpGet("comentarios/{id}")]
        public IActionResult MedicoComentarios(Guid id)
            {
            try
                {
                return Ok(_medicoRepository.MedicoComentarios(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
