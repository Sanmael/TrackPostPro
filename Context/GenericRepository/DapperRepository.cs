using Context.Session;
using System.Data;
using Dapper;
using DomainTrackPostPro.Interfaces;

namespace Context.GenericRepository
{
    public class DapperRepository : IGenericRepository
    {
        private IContext _context;

        public DapperRepository(IContext context)
        {
            _context = context;
        }
      
        public async Task Insert<T>(string query, T param)
        {
            try
            {
                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update<T>(string query, T param)
        {
            try
            {
                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete<T>(string query, T param)
        {
            try
            {
                await _context.DbConnection.ExecuteAsync(query, param, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
