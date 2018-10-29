using FanSoft.AM.Domain.Contracts.Infra;
using System;
using System.Threading.Tasks;

namespace FanSoft.AM.Infra.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly AgendaMedicaDataContext _ctx;
        public UnitOfWorkEF(AgendaMedicaDataContext ctx) => _ctx = ctx;

        public async Task Commit()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
