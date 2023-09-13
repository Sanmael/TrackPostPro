using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePerson(PersonDTO personDTO)
        {
            Person person = personDTO.MapperToEntity();

            await _personRepository.CreatePerson(person);
        }

        public async Task DeletePerson(PersonDTO personDTO)
        {
            try
            {
                await _personRepository.DeletePerson(personDTO.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PersonDTO?> GetPersonById(Guid Id)
        {
            Person person = await _personRepository.GetPersonById(Id);

            if (person == null)
                return null;

            return new PersonDTO().EntityToDto(person);
        }

        public async Task<List<PersonDTO>> GetPersonsByName(string name)
        {
            List<Person> persons = await _personRepository.GetPersonListByName(name);

            List<PersonDTO> result = new List<PersonDTO>();

            Parallel.ForEach(persons, person =>
            {
                result.Add(new PersonDTO().EntityToDto(person));
            });

            return result;
        }
    }
}
