using Aplication.Response;
using MediatR;

namespace Aplication.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<BaseResult>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
