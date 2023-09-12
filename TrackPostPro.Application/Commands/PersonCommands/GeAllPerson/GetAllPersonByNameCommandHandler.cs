using Aplication.Models;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.PersonCommands.GetAllPerson
{
    public class GetAllPersonByNameCommandHandler : IRequestHandler<GetAllPersonByNameCommand, BaseResult<ListPersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPersonByNameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<ListPersonViewModel>> Handle(GetAllPersonByNameCommand request, CancellationToken cancellationToken)
        {
            List<Person> people = await _unitOfWork.PersonRepository.GetPersonListByName(request.Name);

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