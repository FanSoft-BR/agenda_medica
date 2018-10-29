using FanSoft.AM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanSoft.AM.Domain.Contracts.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
    }

    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
