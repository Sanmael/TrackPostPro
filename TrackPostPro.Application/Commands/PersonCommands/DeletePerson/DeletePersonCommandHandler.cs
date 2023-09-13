using DomainTrackPostPro.Interfaces;
using MediatR;
using DomainTrackPostPro.Entities;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.DTos;
using Aplication.Response;

namespace TrackPostPro.Application.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResult<Guid>>
    {
        private readonly IPersonService _personService;

        public DeletePersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<BaseResult<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDTO person = await _personService.GetPersonById(request.Id);

                if (person == null)
                    return new BaseResult<Guid>(Guid.Empty, success: false, message: "Pessoa não encontrada")!;

                bool success = await _personService.DeletePerson(person);

                return new BaseResult<Guid>(request.Id, success: success);
            }
            catch
            {
                throw;
            }          
        }
    }
}
