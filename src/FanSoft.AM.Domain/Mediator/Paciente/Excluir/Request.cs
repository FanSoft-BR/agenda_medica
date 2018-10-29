using MediatR;

namespace FanSoft.AM.Domain.Mediator.Paciente.Excluir
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
