using Aplication.Commands.PersonCommands.CreatePerson;
using Aplication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrackPostPro.Application.Commands.PersonCommands.DeletePerson;
using TrackPostPro.Application.Commands.PersonCommands.GetAllPerson;
using TrackPostPro.Application.Commands.PersonCommands.GetPerson;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPersonAsync(CreatePersonCommand query)
        {
            try
            {
                BaseResult<Guid> result = await _mediator.Send(query);

                if (result.Success)
                    return CreatedAtAction(nameof(GetPersonById), new { id = result.Data }, result);

                return BadRequest(result.Message);
            }
            catch (TrackPostPro.Application.ValidationErrorLogs.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError ,ErrorMessage.InternalServerErrorMessage);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            GetPersonCommand query = new GetPersonCommand() { Id = id };

            var result = await _mediator.Send(query);

            if (result.Success)
                return Ok(result.Data);

            return NotFound(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonsByName(string name)
        {
            GetAllPersonByNameCommand query = new GetAllPersonByNameCommand() { Name = name };

            BaseResult<List<PersonDTO>> result = await _mediator.Send(query);

            if (result.Success)
                return Ok(result.Data);

            return NotFound(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            DeletePersonCommand query = new DeletePersonCommand() { Id = id };

            BaseResult<Guid> result = await _mediator.Send(query);

            if (result.Success)
                return NoContent();

            return NotFound(result.Message);
        }
    }
}
