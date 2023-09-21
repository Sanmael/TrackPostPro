using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System.Security.Cryptography;
using System.Text;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private const string AllCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task CreateToken(TokenDTO tokenDTO)
        {
            string hashToken = GenerateRandomHash();

            Token token = new Token(tokenDTO.UserId, hashToken, CreateHash(tokenDTO.HashPass, hashToken));

            await _tokenRepository.CreateToken(token);
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

            int length = random.Next(6,6);

            StringBuilder hashBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(AllCharacters.Length);
                char randomCharacter = AllCharacters[index];
                hashBuilder.Append(randomCharacter);
            }

            return hashBuilder.ToString();
        }

        public async Task ResetTokenAsync(TokenDTO tokenDTO)
        {
            Token token = await _tokenRepository.GetToken(tokenDTO.UserId);

            string hashToken = GenerateRandomHash();

            token.UpdateToken(hashToken, CreateHash(tokenDTO.HashPass, hashToken));

            await _tokenRepository.ResetCredential(token);
        }

        public async Task<TokenDTO> GetToken(Guid userId)
        {
            Token token = await _tokenRepository.GetToken(userId);

            return new TokenDTO(token.UserId, token.HashPass, token.TextClear);
        }

        public async Task DeleteToken(Guid userId)
        {
            try
            {
                Token token = await _tokenRepository.GetToken(userId);

                if (token != null)
                    await _tokenRepository.DeleteToken(token);
            }
            catch
            {
                throw;
            }

        }
    }
}
