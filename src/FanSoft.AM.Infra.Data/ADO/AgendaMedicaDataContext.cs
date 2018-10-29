using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FanSoft.AM.Infra.Data.ADO
{
    public class AgendaMedicaDataContext : IDisposable
    {
        private readonly SqlConnection _conn;
        public AgendaMedicaDataContext(IConfiguration config)
        {
            var connString = config.GetConnectionString("AgendaMedicaConn");
            _conn = new SqlConnection(connString);
            _conn.Open();
        }

        public void ExecuteCommand(string sql)
        {
            var command = new SqlCommand()
            {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text,
                Connection = _conn
            };
            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteCommandWithData(string query)
        {
            var command = new SqlCommand(query, _conn);
            return command.ExecuteReader();
        }

        public async Task<SqlDataReader> ExecuteCommandWithDataAsync(string query)
        {
            var command = new SqlCommand(query, _conn);
            return await command.ExecuteReaderAsync();
        }

        public void Dispose()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}
