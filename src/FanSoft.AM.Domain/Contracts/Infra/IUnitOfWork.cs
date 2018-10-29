using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Contracts.Infra
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task RollBack();
    }
}
