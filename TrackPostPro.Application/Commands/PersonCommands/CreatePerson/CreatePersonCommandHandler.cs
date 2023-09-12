using Aplication.Models;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using MediatR;
using System.Collections.Generic;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult<Guid>>
    {
        
        private readonly IPersonValidation _personValidation;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler( IPersonValidation personValidation, IUnitOfWork unitOfWork)
        {
            _personValidation = personValidation;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool nameExceededLimit = await _personValidation.ValidateExistNamesAsync(request.Name);

                if (nameExceededLimit)
                    return new BaseResult<Guid>(Guid.Empty, success: false, message: "Nome já existe para mais de 2 pessoas.");

                Person person = request.MapperToEntity();

                _unitOfWork.BeginTransaction();

                await _unitOfWork.PersonRepository.CreatePerson(person);

                await _unitOfWork.TokenRepository.CreateToken(person.Id, request.Password);

                _unitOfWork.Commit();

                return new BaseResult<Guid>(person.Id, message: $"Pessoa criada com sucesso");
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
