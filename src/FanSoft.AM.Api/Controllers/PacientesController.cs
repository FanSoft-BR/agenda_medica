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

        [HttpGet("{id:int}", Name = "GetPacienteById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _pacienteRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Paciente.Inserir.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetPacienteById", new { id = response.Result.Id }, response.Result);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Domain.Mediator.Paciente.Atualizar.Request request)
        {
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new Domain.Mediator.Paciente.Excluir.Request();
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

    }
}
