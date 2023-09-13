using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult<Guid>>
    {

        private readonly IPersonValidation _personValidation;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IPersonService _personService;

        public CreatePersonCommandHandler(IPersonValidation personValidation, IUnitOfWork unitOfWork, ITokenService tokenService, IPersonService personService)
        {
            _personValidation = personValidation;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _personService = personService;
        }

        public async Task<BaseResult<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool nameExceededLimit = await _personValidation.ValidateExistNamesAsync(request.Name);

                if (nameExceededLimit)
                    return new BaseResult<Guid>(Guid.Empty, success: false, message: "Nome já existe para mais de 2 pessoas.");

                _unitOfWork.BeginTransaction();

                PersonDTO person = new PersonDTO(request.Name,request.Age);

                await _personService.CreatePerson(person);

                TokenDTO token = new TokenDTO(person.Id, request.Password);

                await _tokenService.CreateToken(token);

                _unitOfWork.Commit();

                return new BaseResult<Guid>(person.Id, message: "Pessoa criada com sucesso");
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
