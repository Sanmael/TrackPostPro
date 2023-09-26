using Aplication.Response;
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
        [ServiceFilter(typeof(UserFilterAttribute))]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> CreateNewPersonAsync(PersonRequest personRequest)
        {
            BaseResult<PersonDTO> person = (BaseResult<PersonDTO>)await _modelValidation.PersonValidation(personRequest);

            if (!person.Success)
                return BadRequest(person.Message);

            await _personService.CreatePerson(person.Data!);

            return CreatedAtAction(nameof(GetPersonById), new { id = person.Data!.Id }, person.Data);
        }

        //refatorar dps
        [HttpGet("{id}")]
        [ServiceFilter(typeof(UserFilterAttribute))]
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
                await _cachingService.SetAsync((nameof(GetPersonById) + id), JsonConvert.SerializeObject(personDTO));
                return Ok(personDTO);
            }

            return NotFound();
        }

        //refatorar dps
        [HttpGet]
        [ServiceFilter(typeof(UserFilterAttribute))]
        [ServiceFilter(typeof(LogExceptionFilter))]
        public async Task<IActionResult> GetPersonsByName(string name)
        {
            List<PersonDTO> personDtos = new List<PersonDTO>();

            var result = await _cachingService.GetAsync((nameof(GetPersonsByName) + name));

            if (!string.IsNullOrWhiteSpace(result))
            {
                personDtos = JsonConvert.DeserializeObject<List<PersonDTO>>(result)!;

                return Ok(personDtos);
            }

            personDtos = await _personService.GetPersonsByName(name);

            if (!personDtos.Any())
                return NotFound(ValidationMessages.NoPeopleFoundWithSpecifiedName);

            await _cachingService.SetAsync((nameof(GetPersonsByName) + name), JsonConvert.SerializeObject(personDtos));

            return Ok(personDtos);

        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(UserFilterAttribute))]
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
