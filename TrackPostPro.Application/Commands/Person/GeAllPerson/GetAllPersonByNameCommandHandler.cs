using Aplication.Models;
using Context.Repositories;
using Entities.Interfaces;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.GetAllPerson
{
    public class GetAllPersonByNameCommandHandler : IRequestHandler<GetAllPersonByNameCommand, BaseResult<ListPersonViewModel>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonByNameCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResult<ListPersonViewModel>> Handle(GetAllPersonByNameCommand request, CancellationToken cancellationToken)
        {
            List<Entities.Person> people = await _personRepository.GetPersonListByName(request.Name);

            if (!people.Any())
            {
                return new BaseResult<ListPersonViewModel>(null, success: false, "Pessoas não encontradas!");
            }
            ListPersonViewModel listPersonViewModel = new ListPersonViewModel();

            listPersonViewModel.MappingEntityToList(people);

            return new BaseResult<ListPersonViewModel>(listPersonViewModel);
        }
    }
}