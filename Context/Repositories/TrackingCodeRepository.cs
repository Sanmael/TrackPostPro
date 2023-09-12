using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;

namespace Context.Repositories
{
    public class TrackingCodeRepository : ITrackingCodeRepository
    {
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public TrackingCodeRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }
        public async Task CreateTrackingCode(TrackingCode trackingCode)
        {
            try
            {
                string query = "INSERT INTO TrackingCode (Id,CreationDate,UpdateDate,PersonId,Code,Status,NextSearch,NumberOfTries) Values (@Id,@CreationDate,@UpdateDate,@PersonId,@Code,@Status,@NextSearch,@NumberOfTries)";

                await _genericRepository.Insert(query: query, param: trackingCode);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TrackingCode> GetTrackingCodeByCode(string code)
        {
            try
            {
                string query = "SELECT * FROM TrackingCode WHERE Code = @Code";

                return await _context.DbConnection.QueryFirstOrDefaultAsync<TrackingCode>(sql: query, new TrackingCode { Code = code });
            }
            catch
            {
                throw;
            }
        }
    }
}
