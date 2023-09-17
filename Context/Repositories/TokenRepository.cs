using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;

namespace Context.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public TokenRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public async Task CreateToken(Token token)
        {
            try
            {
                await _genericRepository.Insert(param: token);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteToken(Token token)
        {
            try
            {
                await _genericRepository.Delete<Token>(param: token);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Token> GetToken(Guid personId)
        {
            try
            {
                string query = "SELECT * FROM Token WHERE PersonId = @Id";

                return await _context.DbConnection.QueryFirstOrDefaultAsync<Token>(sql: query, param: new { Id = personId });
            }
            catch
            {
                throw;
            }
        }

        public async Task ResetCredential(Token token)
        {
            try
            {
                string query = "Update Token Set TextClear = @TextClear , HashPass = @HashPass, where PersonId = @PersonId";

                await _genericRepository.Update<Token>(query: query, param: token);
            }
            catch
            {
                throw;
            }
        }
    }
}