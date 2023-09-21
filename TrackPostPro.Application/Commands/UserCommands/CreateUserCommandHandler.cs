using Aplication.Response;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace Aplication.Commands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResult>
    {
        private readonly IUserService _userService;
        private readonly ILoggerService _loggerService;

        public CreateUserCommandHandler(IUserService userService, ILoggerService loggerService)
        {
            _userService = userService;
            _loggerService = loggerService;
        }

        public async Task<BaseResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserDTO user = new UserDTO(request.UserName, request.Password,request.Email);

                await _userService.CreateUser(user);

                return new BaseResult(success : true, message: ValidationMessages.SuccessfullyCreatedUser);
            }
            catch (Exception ex)
            {
                await _loggerService.SaveLog(ex, ex.Message, ex.TargetSite?.DeclaringType?.DeclaringType?.Name);

                throw;
            }
        }
    }
}
