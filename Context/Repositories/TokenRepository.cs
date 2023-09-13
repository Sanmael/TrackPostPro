using Context.GenericRepository;
using Context.Session;
using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

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
                string query = "INSERT INTO Token (Id, Personid, HashPass, TextClear) VALUES (@Id, @PersonId, @HashPass, @TextClear)";

                await _genericRepository.Insert(query: query, param: token);
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