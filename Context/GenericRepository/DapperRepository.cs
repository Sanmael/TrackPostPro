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
      
        public async Task Insert<T>(T entity)
        {
            try
            {
                string sql = $"INSERT INTO {typeof(T).Name} ({GetColumns<T>()}) VALUES ({GetParameters<T>()})";

                await _context.DbConnection.ExecuteAsync(sql, entity, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update<T>(string query, T entity)
        {
            try
            {
                await _context.DbConnection.ExecuteAsync(query, entity, _context.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete<T>(T entity)
        {
            try
            {
                string sql = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";

                object id = typeof(T).GetProperty("Id")!.GetValue(entity, null)!;

                await _context.DbConnection.ExecuteAsync(sql, id, _context.Transaction);
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
