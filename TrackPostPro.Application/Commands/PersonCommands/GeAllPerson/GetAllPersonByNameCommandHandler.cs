using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

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
            List<PersonDTO> personDTOs = await _personService.GetPersonsByName(request.Name);

            if (!personDTOs.Any())
                return new BaseResult<List<PersonDTO>>(null, success: false, "Pessoas não encontradas!");


            return new BaseResult<List<PersonDTO>>(personDTOs);
        }
    }
}