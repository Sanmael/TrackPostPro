using DomainTrackPostPro.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Context.Session
{
    public class DapperSession : IDisposable, IContext
    {
        public IDbConnection DbConnection { get; }
        public IDbTransaction? Transaction { get; set; }
        public DapperSession(IConfiguration configuration)
        {
            DbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnections"));

            DbConnection.Open();
        }
        public void Dispose()
        {
            DbConnection?.Dispose();
        }
    }
}
