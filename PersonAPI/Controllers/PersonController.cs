using Aplication.Commands.PersonCommands.CreatePerson;
using Aplication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrackPostPro.Application.Commands.PersonCommands.DeletePerson;
using TrackPostPro.Application.Commands.PersonCommands.GetAllPerson;
using TrackPostPro.Application.Commands.PersonCommands.GetPerson;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICachingService _cachingService;

        public PersonController(IMediator mediator, ICachingService cachingService)
        {
            _mediator = mediator;
            _cachingService = cachingService;
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
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage.InternalServerErrorMessage);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            BaseResult<PersonDTO> baseResult;

            GetPersonCommand query = new GetPersonCommand() { Id = id };
            try
            {                              
                var result = await _cachingService.GetAsync(id.ToString());

                if (!string.IsNullOrWhiteSpace(result))
                {
                    baseResult = JsonConvert.DeserializeObject<BaseResult<PersonDTO>>(result)!;

                    return Ok(baseResult.Data);
                }

                baseResult = await _mediator.Send(query);

                if (baseResult.Success)
                {
                    await _cachingService.SetAsync(id.ToString(), JsonConvert.SerializeObject(baseResult));
                    return Ok(baseResult.Data);
                }

                return NotFound(baseResult.Message);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonsByName(string name)
        {
            try
            {
                GetAllPersonByNameCommand query = new GetAllPersonByNameCommand() { Name = name };

                BaseResult<List<PersonDTO>> result = await _mediator.Send(query);

                if (result.Success)
                    return Ok(result.Data);

                return NotFound(result.Message);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
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
