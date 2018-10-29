using FanSoft.AM.Domain.Contracts.Repositories;
using FanSoft.AM.Domain.Entities;

namespace FanSoft.AM.Infra.Data.EF.Repositories
{
    public class PacienteReadRepositoryEF : ReadRepositoryEF<Paciente>, IPacienteReadRepository
    {
        public PacienteReadRepositoryEF(AgendaMedicaDataContext ctx) : base(ctx){ }
    }

    public class PacienteWriteRepositoryEF : WriteRepositoryEF<Paciente>, IPacienteWriteRepository
    {
        public PacienteWriteRepositoryEF(AgendaMedicaDataContext ctx) : base(ctx){ }
    }
}
