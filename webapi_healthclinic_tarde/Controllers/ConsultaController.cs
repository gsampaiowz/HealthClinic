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
    public class ConsultaController : ControllerBase
        {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController()
            {
            _consultaRepository = new ConsultaRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_consultaRepository.Listar());

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
                return Ok(_consultaRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
            {
            try
                {
                _consultaRepository.Cadastrar(consulta);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Consulta consulta)
            {
            try
                {
                consulta.IdConsulta = id;
                _consultaRepository.Atualizar(id, consulta);
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
                _consultaRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
