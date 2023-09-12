using DomainTrackPostPro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Validations
{
    public class PersonValidation : IPersonValidation
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ValidateExistNamesAsync(string name)
        {
            var list = await _unitOfWork.PersonRepository.GetPersonListByName(name);

            return list.Count >= 2; 
        }
    }
}
