using FanSoft.AM.Domain.DTOs;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Contracts.Infra.Service
{
    public interface ISendMail
    {
        Task Send(EMailMessage data);
    }
}
