using Aplication.Commands.PersonCommands.CreatePerson;
using Aplication.Response;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrackPostPro.Application.Commands.PersonCommands.DeletePerson;
using TrackPostPro.Application.Commands.PersonCommands.GetAllPerson;
using TrackPostPro.Application.Commands.PersonCommands.GetPerson;
using TrackPostPro.Application.DTos;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreatePersonCommand> _validator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPersonAsync(CreatePersonCommand query)
        {
            BaseResult<Guid> result = await _mediator.Send(query);

            if (result.Success)
                return CreatedAtAction(nameof(GetPersonById), new { id = result.Data }, result);

            return BadRequest(result.Message);
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

            BaseResult<List<PersonDTO>> result  = await _mediator.Send(query);

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
