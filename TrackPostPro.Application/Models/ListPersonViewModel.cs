using Entities;

namespace TrackPostPro.Application.Models
{
    public class ListPersonViewModel
    {
        public List<PersonViewModel> PersonViewModels {  get; set; }

        public void MappingEntityToList(List<Person> people)
        {
            PersonViewModels = new List<PersonViewModel>();

            foreach (var person in people)
            {
                PersonViewModels.Add(new PersonViewModel().MapperEntityToModel(person));
            };
        }
    }
}
