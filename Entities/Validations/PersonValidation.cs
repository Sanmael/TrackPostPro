﻿using DomainTrackPostPro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Validations
{
    public class PersonValidation : IPersonValidation
    {
        private readonly IPersonRepository _personRepository;

        public PersonValidation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }       
    }
}
