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
    public class EspecialidadeController : ControllerBase
        {
        private readonly EspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
            {
            _especialidadeRepository = new EspecialidadeRepository();
            }

        [Authorize(Roles = "Administrador, Médico, Paciente")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_especialidadeRepository.Listar());

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
                return Ok(_especialidadeRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
            {
            try
                {
                _especialidadeRepository.Cadastrar(especialidade);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
            {
            try
                {
                especialidade.IdEspecialidade = id;
                _especialidadeRepository.Atualizar(id, especialidade);
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
                _especialidadeRepository.Deletar(id);
                return Ok();
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet("medicos/{id}")]
        public IActionResult ListarMedicos(Guid id)
            {
            try
                {
                return Ok(_especialidadeRepository.ListarMedicos(id));
                }
            catch (Exception e)
                {

                return BadRequest(e);
                }
            }
        }
    }
