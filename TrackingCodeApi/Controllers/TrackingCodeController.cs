using Aplication.Response;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackPostPro.Application.Commands.TrackingCodeCommands;
using TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;

namespace TrackingCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingCodeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrackingCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTrackingCode(Guid personId, string code)
        {
            try
            {
                TrackingCodeInsertCommand command = new TrackingCodeInsertCommand() { PersonId = personId, Code = code };

                BaseResult<Guid> result = await _mediator.Send(command);

                if (result.Success)
                    return CreatedAtAction(result.Message, result);

                return BadRequest(result.Message);
            }
            catch (TrackPostPro.Application.ValidationErrorLogs.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage.InternalServerErrorMessage);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTrackingCodeByCode(string code)
        {
            TrackingCodeGetCommand command = new TrackingCodeGetCommand() { Code = code };

            BaseResult<TrackingCodeDTO> result = await _mediator.Send(command);

            if (result.Success)
                return Ok(result.Data);

            return NotFound(result);
        }
    }
}
