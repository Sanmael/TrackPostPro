using Context.Session;
using Entities.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Context.GenericRepository
{
    public class DapperRepository : IGenericRepository
    {
        private IContext _context;
        private readonly IConfiguration _configuration;

        public DapperRepository(IContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            if (_context?.DbConnection?.State == ConnectionState.Closed || _context == null)
            {
                _context = new DapperSession(_configuration);
            }

            return _context.DbConnection;
        }

        public async Task Insert<T>(string query, T param)
        {
            try
            {
                GetConnection();

                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update<T>(string query, T param)
        {
            try
            {
                GetConnection();

                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete<T>(string query, T param)
        {
            try
            {
                GetConnection();

                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
