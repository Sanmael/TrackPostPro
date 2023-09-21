using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            User user = new User(userDTO.UserName, userDTO.Email, isAdmin: false);
            
            try
            {
                _unitOfWork.BeginTransaction();

                await _userRepository.CreateUser(user);

                userDTO.Token.UserId = user.Id;

                await _tokenService.CreateToken(userDTO.Token);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
