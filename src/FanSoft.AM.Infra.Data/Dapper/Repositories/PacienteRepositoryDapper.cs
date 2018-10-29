using Dapper;
using FanSoft.AM.Domain.Contracts.Repositories;
using FanSoft.AM.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FanSoft.AM.Infra.Data.Dapper.Repositories
{
    public class PacienteReadRepositoryDapper : IPacienteReadRepository
    {
        private readonly SqlConnection _conn;
        private string _query;

        public PacienteReadRepositoryDapper(AgendaMedicaDataContext ctx)
        {
            _conn = ctx._conn;
            _query = $@"SELECT 
	                        p.Id, p.Nome, p.Sobrenome, p.Nascimento, p.SexoId FROM Paciente p";
        }

        public IEnumerable<Paciente> Get()
        {
            return _conn.Query<Paciente>(_query);
        }

        public Paciente Get(int id)
        {
            return _conn.QueryFirstOrDefault<Paciente>(_query + $" WHERE p.Id = @id", new { id });
        }

        public async Task<IEnumerable<Paciente>> GetAsync()
        {
            return await _conn.QueryAsync<Paciente>(_query);
        }

        public async Task<Paciente> GetAsync(int id)
        {
            return await _conn.QueryFirstOrDefaultAsync<Paciente>(_query + $" WHERE p.Id = @id", new { id });

        }
    }
}
