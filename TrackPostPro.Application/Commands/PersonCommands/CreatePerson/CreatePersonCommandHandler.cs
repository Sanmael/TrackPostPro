using Aplication.Response;
using Context.Repositories;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult>
    {
        private readonly IPersonService _personService;
        private readonly ILoggerService _loggerService;

        public CreatePersonCommandHandler(IPersonValidation personValidation, IPersonService personService, ILoggerService loggerService)
        {
            _personService = personService;
            _loggerService = loggerService;
        }

        public async Task<BaseResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDTO person = new PersonDTO(request.Name, request.BirthDate, request.City, request.State, request.PostalCode, request.Neighborhood, request.PublicPlace);

                await _personService.CreatePerson(person);

                return new BaseResult(message: ValidationMessages.SuccessfullyCreatedPerson);
            }
            catch (Exception ex)
            {
                await _loggerService.SaveLog(ex, ex.Message, ex.TargetSite?.DeclaringType?.DeclaringType?.Name);

                throw;
            }
        }
    }
}
