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
    public class PacienteController : ControllerBase
        {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController()
            {
            _pacienteRepository = new PacienteRepository();
            }

        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_pacienteRepository.Listar());

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
                return Ok(_pacienteRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
            {
            try
                {
                _pacienteRepository.Cadastrar(paciente);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
            {
            try
                {
                paciente.IdPaciente = id;
                _pacienteRepository.Atualizar(id, paciente);
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
                _pacienteRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
