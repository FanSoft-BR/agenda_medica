using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Contracts.Infra.Data
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task RollBack();
    }
}
