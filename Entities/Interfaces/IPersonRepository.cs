using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IPersonRepository 
    {
        public Task<Person> GetPersonById(Guid id);
        public Task<List<Person>> GetPersonListByName(string name);
            
        public Task CreatePerson(Person person);
        public Task UpdatePerson(Person person);
        public Task DeletePerson(Guid id);
    }
}
                                