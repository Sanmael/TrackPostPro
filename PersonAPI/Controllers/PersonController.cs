using Aplication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Filters;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Interfaces.Validation;
using TrackPostPro.Application.Requests;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ICachingService _cachingService;
        private readonly IPersonService _personService;
        private readonly IModelValidation _modelValidation;

        public PersonController(ICachingService cachingService, IPersonService personService, IModelValidation modelValidation)
        {
            _cachingService = cachingService;
            _personService = personService;
            _modelValidation = modelValidation;
        }

        [HttpPost]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> CreateNewPersonAsync(PersonRequest personRequest)
        {
            PersonDTO person = new PersonDTO(personRequest.Name, personRequest.BirthDate, personRequest.PostalCode);

            BaseResult<PersonDTO> validation = await _modelValidation.PersonValidation(person);

            if (!validation.Success)
                return BadRequest(validation.Message);

            await _personService.CreatePerson(validation.Data!);

            return CreatedAtAction(nameof(GetPersonById), new { id = validation.Data!.Id }, validation.Data);
        }

        //refatorar dps
        [HttpGet("{id}")]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            PersonDTO personDTO = new PersonDTO();
             
            var result = await _cachingService.GetAsync(id.ToString());

            if (!string.IsNullOrWhiteSpace(result))
            {
                personDTO = JsonConvert.DeserializeObject<PersonDTO>(result)!;

                return Ok(personDTO);
            }

            personDTO = await _personService.GetPersonById(id);

            if (personDTO != null)
            {
                await _cachingService.SetAsync(id.ToString(), JsonConvert.SerializeObject(personDTO));
                return Ok(personDTO);
            }

            return NotFound();
        }

        [HttpGet]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> GetPersonsByName(string name)
        {
            List<PersonDTO> personDtos = await _personService.GetPersonsByName(name);

            if (!personDtos.Any())
                return NotFound(ValidationMessages.NoPeopleFoundWithSpecifiedName);

            return Ok(personDtos);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            PersonDTO personDto = await _personService.GetPersonById(id);

            if (personDto == null)
                return NotFound(ValidationMessages.PersonNotFound);

            await _personService.DeletePerson(personDto);

            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
