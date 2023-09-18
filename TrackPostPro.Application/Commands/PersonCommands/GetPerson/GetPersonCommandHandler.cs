using Aplication.Response;
using MediatR;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

namespace TrackPostPro.Application.Commands.PersonCommands.GetPerson
{
    public class GetPersonCommandHandler : IRequestHandler<GetPersonCommand, BaseResult<PersonDTO>>
    {
        private readonly IPersonService _personService;
        
        public GetPersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<BaseResult<PersonDTO>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDTO person = await _personService.GetPersonById(request.Id);

                if (person == null)
                    throw new ValidationException(ValidationMessages.PersonNotFound);

                return new BaseResult<PersonDTO>(person);
            }
            catch
            {
                throw;
            }
        }
    }
}