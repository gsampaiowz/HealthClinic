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
    public class ClinicaController : ControllerBase
        {
        private readonly ClinicaRepository _clinicaRepository;

        public ClinicaController()
            {
            _clinicaRepository = new ClinicaRepository();
            }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_clinicaRepository.Listar());

                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_clinicaRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Clinica clinica)
            {
            try
                {
                _clinicaRepository.Cadastrar(clinica);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinica)
            {
            try
                {
                clinica.IdClinica = id;
                _clinicaRepository.Atualizar(id, clinica);
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
                _clinicaRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet("medicos/{id}")]
        public IActionResult ClinicaMedicos(Guid id)
            {
            try
                {
                return Ok(_clinicaRepository.ClinicaMedicos(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
