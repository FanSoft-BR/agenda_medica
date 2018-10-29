using MediatR;
using System;

namespace FanSoft.AM.Domain.Mediator.Paciente.Atualizar
{
    public class Request : IRequest<Response>
    {
        public Request() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public int SexoId { get; set; }
    }
}
