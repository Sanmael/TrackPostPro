using Aplication.Models;
using Context.Repositories;
using Context.UOW;
using Entities;
using Entities.Interfaces;
using Entities.Validations;
using MediatR;
using System.Collections.Generic;

namespace Aplication.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult<Guid>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IPersonValidation _personValidation;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IPersonValidation personValidation, ITokenRepository tokenRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _personValidation = personValidation;
            _tokenRepository = tokenRepository;
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

                await _personRepository.CreatePerson(person);

                await _tokenRepository.CreateToken(person.Id, request.Password);

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
