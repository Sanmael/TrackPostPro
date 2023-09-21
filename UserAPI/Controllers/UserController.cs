using Aplication.Commands.UserCommands;
using Aplication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrackPostPro.Application.CustomMessages;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            try
            {
                BaseResult result = await _mediator.Send(createUserCommand);

                if (result.Success)
                    return StatusCode(StatusCodes.Status201Created, result.Message);

                return BadRequest(result.Message);
            }          
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage.InternalServerErrorMessage);
            }
        }
    }
}
