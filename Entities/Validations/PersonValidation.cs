using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validations
{
    public class PersonValidation : IPersonValidation
    {
        private readonly IPersonRepository _personRepository;

        public PersonValidation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> ValidateExistNamesAsync(string name)
        {
            var list = await _personRepository.GetPersonListByName(name);

            return list.Count >= 2; 
        }
    }
}
