using MediatR;
using System;

namespace FanSoft.AM.Domain.Mediator.Paciente
{
    public class Notification : INotification
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        public override string ToString()
            => $"Paciente {NomeCompleto} inserido com sucesso em {DataHora}";
    }
}
