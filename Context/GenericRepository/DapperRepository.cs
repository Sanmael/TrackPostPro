using System.Data;
using System.Reflection;
using Dapper;
using DomainTrackPostPro.Interfaces;
using static Dapper.SqlMapper;

namespace Context.GenericRepository
{
    public class DapperRepository : IGenericRepository
    {
        private IContext _context;

        public DapperRepository(IContext context)
        {
            _context = context;
        }
      
        public async Task Insert<T>(T param)
        {
            try
            {
                string sql = $"INSERT INTO {typeof(T).Name} ({GetColumns<T>()}) VALUES ({GetParameters<T>()})";

                await _context.DbConnection.ExecuteAsync(sql, param, _context.Transaction);
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

        public async Task Delete<T>(T param)
        {
            try
            {
                string sql = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";

                var id = typeof(T).GetProperty("Id")!.GetValue(param, null);

                await _context.DbConnection.ExecuteAsync(sql, param, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetColumns<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => p.Name));
        }

        private string GetParameters<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }
    }
}
