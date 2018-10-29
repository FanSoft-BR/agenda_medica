using FanSoft.AM.Domain.Contracts.Infra;
using FanSoft.AM.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Commands.Paciente.Inserir
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IPacienteWriteRepository _pacienteWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IPacienteWriteRepository pacienteWriteRepository, IUnitOfWork uow)
        {
            _pacienteWriteRepository = pacienteWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var paciente = new Entities.Paciente(request.Nome, request.Sobrenome, request.Nascimento, request.SexoId);
            _pacienteWriteRepository.Add(paciente);
            await _uow.Commit();
            return new Response(paciente);
        }
    }
}
