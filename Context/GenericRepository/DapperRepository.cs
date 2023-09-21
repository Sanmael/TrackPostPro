using System.Data;
using System.Reflection;
using Dapper;
using DomainTrackPostPro.Entities;
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
                string sql = $"INSERT INTO [{typeof(T).Name}] ({GetColumns<T>()}) OUTPUT INSERTED.Id VALUES ({GetParameters<T>()})";

                Guid id = await _context.DbConnection.QuerySingleAsync<Guid>(sql, entity, _context.Transaction);

                typeof(T).GetProperty("Id")!.SetValue(entity, id);
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
            PropertyInfo[] properties = typeof(T).GetProperties().Where(x => x.Name != "Id").ToArray();
            return string.Join(", ", properties.Select(p => p.Name));
        }

        private string GetParameters<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties().Where(x => x.Name != "Id").ToArray();            
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }
    }
}
