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
    public class InstituicaoController : ControllerBase
        {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
            {
            _instituicaoRepository = new InstituicaoRepository();
            }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
            {
            try
                {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_instituicaoRepository.Listar());
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
                return Ok(_instituicaoRepository.BuscarPorId(id));
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
                _instituicaoRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
            {
            try
                {
                _instituicaoRepository.Atualizar(id, instituicao);
                return StatusCode(204);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
