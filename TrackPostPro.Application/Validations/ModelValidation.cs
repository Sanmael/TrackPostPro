using Aplication.Response;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Interfaces.Validation;
using TrackPostPro.Application.Requests;
using TrackPostPro.Application.Response;

namespace TrackPostPro.Application.Validations
{
    public class ModelValidation : IModelValidation
    {
        private readonly IAPIRequester _apiRequester;

        public ModelValidation(IAPIRequester apiRequester)
        {
            _apiRequester = apiRequester;
        }

        public async Task<IBaseResult<PersonDTO>> PersonValidation(PersonRequest personRequest)
        {
            BaseResult<AddressDTO> cepValidation = (BaseResult<AddressDTO>)await _apiRequester.GetAddressByExternalAPI(personRequest.PostalCode);

            if (!cepValidation.Success)
                return new BaseResult<PersonDTO>(message: cepValidation.Message!, success: false);

            PersonDTO personDTO = new PersonDTO(personRequest.Name, personRequest.BirthDate, cepValidation.Data!);

            return new BaseResult<PersonDTO>(personDTO);
        }
    }
}
