using FanSoft.AM.Domain.Contracts.Infra.Data;
using FanSoft.AM.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Mediator.Paciente.Inserir
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IPacienteWriteRepository _pacienteWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IMediator mediator, IPacienteWriteRepository pacienteWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _pacienteWriteRepository = pacienteWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var paciente = new Entities.Paciente(request.Nome, request.Sobrenome, request.Nascimento, request.SexoId);
            _pacienteWriteRepository.Add(paciente);
            await _uow.Commit();

            await _mediator.Publish(new Notification {
                Id = paciente.Id, NomeCompleto = paciente.NomeCompleto
            });

            return new Response(paciente);
        }
    }
}
