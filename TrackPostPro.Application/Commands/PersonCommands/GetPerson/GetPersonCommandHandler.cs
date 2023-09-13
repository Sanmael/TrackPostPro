using Aplication.Response;
using MediatR;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Entities;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Commands.PersonCommands.GetPerson
{
    public class GetPersonCommandHandler : IRequestHandler<GetPersonCommand, BaseResult<PersonDTO>>
    {
        private readonly IPersonService _personService;

        public GetPersonCommandHandler(IPersonService personService )
        {
            _personService = personService;
        }

        public async Task<BaseResult<PersonDTO>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            PersonDTO person = await _personService.GetPersonById(request.Id);

            if (person == null)
                return new BaseResult<PersonDTO>(null, success: false, message: "Pessoa não encontrada.");
             
            return new BaseResult<PersonDTO>(person);
        }
    }
}