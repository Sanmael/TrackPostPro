using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Interfaces
{
    public interface IPersonService
    {
        public Task CreatePerson(PersonDTO personDTO);
        public Task<PersonDTO> GetPersonById(Guid Id);
        public Task<List<PersonDTO>> GetPersonsByName(string name);
        public Task<bool> DeletePerson (PersonDTO personDTO);
    }
}
