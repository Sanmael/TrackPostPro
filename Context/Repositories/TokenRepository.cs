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
                await _genericRepository.Insert(token);
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
                await _genericRepository.Delete<Token>(token);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Token> GetToken(Guid userId)
        {
            try
            {
                string query = "SELECT * FROM Token WHERE UserId = @Id";

                return await _context.DbConnection.QueryFirstOrDefaultAsync<Token>(sql: query, param: new { Id = userId });
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
                string query = "Update Token Set TextClear = @TextClear , HashPass = @HashPass, where UserId = @UserId";

                await _genericRepository.Update<Token>(query: query, token);
            }
            catch
            {
                throw;
            }
        }
    }
}