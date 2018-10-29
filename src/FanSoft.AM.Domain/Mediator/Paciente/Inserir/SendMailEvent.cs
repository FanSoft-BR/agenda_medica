using FanSoft.AM.Domain.Contracts.Infra.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Mediator.Paciente.Inserir
{
    public class SendMailEvent : INotificationHandler<Notification>
    {
        private readonly ISendMail _sendMail;
        public SendMailEvent(ISendMail sendMail)
        {
            _sendMail = sendMail;
        }

        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await _sendMail.Send(new DTOs.EMailMessage {
                To = "fabiano.nalin@gmail.com",
                Subject = "Cadastro de Paciente",
                Body = $"Cadastro e novo paciente: {notification.ToString()}"
            });
        }
    }
}
