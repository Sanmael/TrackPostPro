using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Interfaces
{
    public interface IAddresService
    {
        public Task CreateNewAddres(AddressDTO addressDTO);
    }
}
