using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

namespace TrackPostPro.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAddresService _addresService;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository, IAddresService addresService, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _addresService = addresService;
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePerson(PersonDTO personDTO)
        {                                                              
            try
            {
                Person person = personDTO.MapperPersonEntity();

                _unitOfWork.BeginTransaction();

                await _personRepository.CreatePerson(person);

                personDTO.Address.PersonId = person.Id;
                personDTO.Id = person.Id;

                await _addresService.CreateNewAddres(personDTO.Address);



                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();

                throw;
            }
        }

        public async Task DeletePerson(PersonDTO personDTO)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                await _personRepository.DeletePerson(personDTO.Id);

                await _addresService.DeleteAddress(personDTO.Id);

                _unitOfWork.Commit();

            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<PersonDTO?> GetPersonById(Guid Id)
        {
            Person person = await _personRepository.GetPersonById(Id);

            if (person == null)
                return null;

            PersonDTO personDTO = new PersonDTO(person.Id, person.Name, person.BirthDate);

            personDTO.Address = await _addresService.GetAddressByPersonId(person.Id);

            return personDTO;
        }

        public async Task<List<PersonDTO>> GetPersonsByName(string name)
        {
            List<Person> persons = await _personRepository.GetPersonListByName(name);

            List<PersonDTO> result = new List<PersonDTO>();

            Parallel.ForEach(persons, person =>
            {
                result.Add(new PersonDTO(person.Id, person.Name, person.BirthDate));
            });

            return result;
        }
    }
}
