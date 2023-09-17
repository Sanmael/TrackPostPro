using Aplication.Response;
using Context.Repositories;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult<Guid>>
    {

        private readonly IPersonValidation _personValidation;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonService _personService;
        private readonly ILoggerService _loggerService;

        public CreatePersonCommandHandler(IPersonValidation personValidation, IUnitOfWork unitOfWork, IPersonService personService, ILoggerService loggerService)
        {
            _personValidation = personValidation;
            _unitOfWork = unitOfWork;
            _personService = personService;
            _loggerService = loggerService;
        }

        public async Task<BaseResult<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {

                bool nameExceededLimit = await _personValidation.ValidateExistNamesAsync(request.Name);

                if (nameExceededLimit)
                    return new BaseResult<Guid>(Guid.Empty, success: false, message: "Nome já existe para mais de 2 pessoas.");

                _unitOfWork.BeginTransaction();

                PersonDTO person = new PersonDTO(request.Name, request.Age, request.Password, request.City, request.State, request.PostalCode, request.Neighborhood, request.PublicPlace);                

                await _personService.CreatePerson(person);
              
                _unitOfWork.Commit();

                return new BaseResult<Guid>(person.Id, message: "Pessoa criada com sucesso");
            }
            catch(Exception ex) 
            {
                _unitOfWork.Rollback();                

                await _loggerService.SaveLog(ex, ex.Message, ex.TargetSite!.DeclaringType!.DeclaringType!.Name);

                throw;
            }
        }
    }
}
