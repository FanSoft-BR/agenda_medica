using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Mediator.Paciente.Inserir
{
    public class DebugLogEvent : INotificationHandler<Notification>
    {
        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine(notification.ToString());
            });
        }
    }
}
