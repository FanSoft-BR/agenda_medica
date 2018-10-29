using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace FanSoft.AM.Infra.Data.Dapper
{
    public class AgendaMedicaDataContext : IDisposable
    {
        public SqlConnection _conn { get; private set; }
        public AgendaMedicaDataContext(IConfiguration config)
        {
            var connString = config.GetConnectionString("AgendaMedicaConn");
            _conn = new SqlConnection(connString);
            _conn.Open();
        }

        public void Dispose()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}
