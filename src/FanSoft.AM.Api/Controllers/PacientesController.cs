using FanSoft.AM.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoft.AM.Api.Controllers
{
    [Route("api/v1/pacientes")]
    public class PacientesController : Controller
    {
        private readonly IPacienteReadRepository _pacienteRepository;
        private readonly IMediator _mediator;
        public PacientesController(IPacienteReadRepository pacienteRepository, IMediator mediator)
        {
            _pacienteRepository = pacienteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _pacienteRepository.GetAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Commands.Paciente.Inserir.Request request)
        {

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

    }
}
