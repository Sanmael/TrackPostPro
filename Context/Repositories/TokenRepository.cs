using Context.GenericRepository;
using Context.Session;
using Dapper;
using Entities;
using Entities.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Context.Repositories
{
    public class TokenRepository : ITokenRepository
    {       
        private string _token;
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public TokenRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public async Task CreateToken(Guid personId, string pass)
        {
            _token = GenerateRandomHash();

            Token token = new Token().NewToken(personId, _token, CreateHash(pass, _token));

            string query = "INSERT INTO Token (Id, Personid, HashPass, TextClear) VALUES (@Id, @PersonId, @HashPass, @TextClear)";

            await _genericRepository.Insert(query:query, param: new Token { Id = token.Id, PersonId = token.PersonId, HashPass = token.HashPass, TextClear = token.TextClear });
        }
        public string CreateHash(string pass, string textRandom)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textRandom + pass);

                byte[] hashBytes = sha512.ComputeHash(bytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private string GenerateRandomHash()
        {
            Random random = new Random();

            int length = random.Next(6, 9);

            const string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder hashBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(allCharacters.Length);
                char randomCharacter = allCharacters[index];
                hashBuilder.Append(randomCharacter);
            }

            return hashBuilder.ToString();
        }

        public async Task<Token> GetToken(Guid personId)
        {
            string query = "SELECT * FROM Token WHERE PersonId = @Id";

            return await _context.DbConnection.QueryFirstOrDefaultAsync<Token>(sql:query, param: new { Id = personId });
        }

        public async Task ResetCredential(Guid personId, string pass)
        {
            _token = GenerateRandomHash();

            Token token = await GetToken(personId);

            token.UpdateToken(_token, CreateHash(pass, _token));

            string query = "Update Token Set TextClear = TextClear , HashPass = HashPass, where PersonId = PersonId";

            await _genericRepository.Update<Token>(query: query, param: new Token{ TextClear = token.TextClear, HashPass = token.HashPass, PersonId = token .PersonId});
        }
    }
}