using Aplication.Response;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Interfaces.Validation
{
    public interface IModelValidation
    {
        public Task<BaseResult<PersonDTO>> PersonValidation(PersonDTO personDTO);
    }
}
