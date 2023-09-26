using Aplication.Response;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Response;

namespace TrackPostPro.Application.Interfaces
{
    public interface IAPIRequester
    {
        public Task<IBaseResult<AddressDTO>> GetAddressByExternalAPI(string cep);
    }
}
