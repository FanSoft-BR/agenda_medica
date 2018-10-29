using FanSoft.AM.Domain.Contracts.Infra.Data;
using FanSoft.AM.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Mediator.Paciente.Atualizar
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IPacienteReadRepository _pacienteReadRepository;
        private readonly IPacienteWriteRepository _pacienteWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(
            IMediator mediator, 
            IPacienteWriteRepository pacienteWriteRepository,
            IPacienteReadRepository pacienteReadRepository,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _pacienteWriteRepository = pacienteWriteRepository;
            _pacienteReadRepository = pacienteReadRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var paciente = await _pacienteReadRepository.GetAsync(request.Id);
            //var paciente = new Entities.Paciente(request.Nome, request.Sobrenome, request.Nascimento, request.SexoId);

            if (paciente == null)
            {
                var response = new Response();
                response.AddError($"Paciente de id {request.Id} não encontrado");
                return response;
            }

            paciente.Atualizar(request.Nome, request.Sobrenome, request.Nascimento, request.SexoId);
            _pacienteWriteRepository.Update(paciente);
            await _uow.Commit();

            await _mediator.Publish(new Notification
            {
                Id = paciente.Id,
                NomeCompleto = paciente.NomeCompleto
            });

            return new Response(paciente);
        }
    }
}
