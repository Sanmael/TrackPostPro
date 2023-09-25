using Aplication.Response;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Interfaces.Validation;

namespace TrackPostPro.Application.Validations
{
    public class ModelValidation : IModelValidation
    {
        private readonly IAddresService _addresService;

        public ModelValidation(IAddresService addresService)
        {
            _addresService = addresService;
        }

        public async Task<BaseResult<PersonDTO>> PersonValidation(PersonDTO personDTO)
        {
            personDTO.Address = await _addresService.GetAddress(personDTO.Address.PostalCode);

            if (personDTO.Address == null)
                return new BaseResult<PersonDTO>(success: false, message: "Cep não encontrado.");

            return new BaseResult<PersonDTO>(personDTO, success: true);
        }
    }
}
