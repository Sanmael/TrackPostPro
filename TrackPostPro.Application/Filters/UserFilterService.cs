using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Entities;

public class UserFilterService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserFilterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ValidateCredentialsAsync(string userId, string pass)
    {
        try
        {
            Token token = await _unitOfWork.TokenRepository.GetToken(Guid.Parse(userId));

            string hashPass = _unitOfWork.TokenRepository.CreateHash(pass, token.TextClear);

            return (token.HashPass == hashPass);
        }
        catch
        {
            return false;
        }
    }
}