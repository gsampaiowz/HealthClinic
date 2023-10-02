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
    public class PacienteController : ControllerBase
        {
        private readonly PacienteRepository _pacienteRepository;

        public PacienteController()
            {
            _pacienteRepository = new PacienteRepository();
            }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador, Paciente, Médico")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador, Paciente")]
        [HttpGet("consultas/{id}")]
        public IActionResult PacienteConsultas(Guid id)
            {
            try
                {
                return Ok(_pacienteRepository.PacienteConsultas(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
