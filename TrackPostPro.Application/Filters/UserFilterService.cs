using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Entities;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.DTos;

public class UserFilterService
{
    private readonly ITokenService _tokenService;

    public UserFilterService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task<bool> ValidateCredentialsAsync(string userId, string pass)
    {
        try
        {
            TokenDTO token = await _tokenService.GetToken(Guid.Parse(userId));

            string hashPass = _tokenService.CreateHash(pass, token.TextClear);

            return (token.HashPass == hashPass);
        }
        catch
        {
            return false;
        }
    }
}