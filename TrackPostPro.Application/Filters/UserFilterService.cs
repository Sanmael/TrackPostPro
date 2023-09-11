using Entities.Interfaces;
using Entities;

public class UserFilterService
{
    private readonly ITokenRepository _tokenRepository;

    public UserFilterService(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<bool> ValidateCredentialsAsync(string userId, string pass)
    {
        try
        {
            Token token = await _tokenRepository.GetToken(Guid.Parse(userId));

            string hashPass = _tokenRepository.CreateHash(pass, token.TextClear);

            return (token.HashPass == hashPass);
        }
        catch
        {
            return false;
        }
    }
}