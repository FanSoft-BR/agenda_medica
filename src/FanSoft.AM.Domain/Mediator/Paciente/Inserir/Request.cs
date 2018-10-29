using MediatR;
using System;

namespace FanSoft.AM.Domain.Mediator.Paciente.Inserir
{
    public class Request : IRequest<Response>
    {
        public Request(){}

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public int SexoId { get; set; }
    }
}
