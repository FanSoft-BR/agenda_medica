using FanSoft.AM.Domain.Entities;

namespace FanSoft.AM.Domain.Contracts.Repositories
{
    public interface IPacienteReadRepository : IReadRepository<Paciente>
    { }

    public interface IPacienteWriteRepository : IWriteRepository<Paciente>
    { }
}
