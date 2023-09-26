using Aplication.Response;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Requests;
using TrackPostPro.Application.Response;

namespace TrackPostPro.Application.Interfaces.Validation
{
    public interface IModelValidation
    {
        public Task<IBaseResult<PersonDTO>> PersonValidation(PersonRequest personRequest);
    }
}
