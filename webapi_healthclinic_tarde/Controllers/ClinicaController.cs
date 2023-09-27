using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Listar()
            {
            try
                {
                return Ok(_clinicaRepository.Listar());

                }
            catch (Exception)
                {

                throw;
                }
            }
        }
    }
