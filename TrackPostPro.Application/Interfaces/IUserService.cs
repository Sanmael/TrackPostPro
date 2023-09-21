using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(UserDTO userDTO);
    }
}
