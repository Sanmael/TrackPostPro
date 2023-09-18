using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

namespace TrackPostPro.Application.Commands.PersonCommands.GetAllPerson
{
    public class GetAllPersonByNameCommandHandler : IRequestHandler<GetAllPersonByNameCommand, BaseResult<List<PersonDTO>>>
    {
        private readonly IPersonService _personService;

        public GetAllPersonByNameCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<BaseResult<List<PersonDTO>>> Handle(GetAllPersonByNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<PersonDTO> personDTOs = await _personService.GetPersonsByName(request.Name);

                if (!personDTOs.Any())
                   throw new ValidationException(ValidationMessages.NoPeopleFoundWithSpecifiedName);

                return new BaseResult<List<PersonDTO>>(personDTOs);
            }
            catch
            {
                throw;
            }
        }
    }
}