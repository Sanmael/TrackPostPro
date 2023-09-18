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

                await _genericRepository.Insert(trackingCode);
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
