using Context.Repositories;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System.Transactions;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITokenService _tokenService;
        private readonly IAddresService _addresService;

        public PersonService(IPersonRepository personRepository, ITokenService tokenService, IAddresService addresService)
        {
            _personRepository = personRepository;
            _tokenService = tokenService;
            _addresService = addresService;
        }

        public async Task CreatePerson(PersonDTO personDTO)
        {
            try
            {
                Person person = personDTO.MapperToEntity();

                await _personRepository.CreatePerson(person);

                await _tokenService.CreateToken(personDTO.Token);

                await _addresService.CreateNewAddres(personDTO.Address);
            }
            catch(Exception) 
            {                
                throw;
            }
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

            PersonDTO personDTO = new PersonDTO().EntityToDto(person);

            personDTO.Address = await _addresService.GetAddressByPersonId(person.Id);

            return personDTO;
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
