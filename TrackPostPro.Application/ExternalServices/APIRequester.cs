using Aplication.Response;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.Response;

namespace TrackPostPro.Application.ExternalServices
{
    public class APIRequester : IAPIRequester
    {
        private readonly IConfiguration _configuration;

        public APIRequester(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IBaseResult<AddressDTO>> GetAddressByExternalAPI(string cep)
        {
            cep = cep.Replace("-", "");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("CepUrl"));

                string relativeUrl = $"ws/{cep}/json/";

                var response = await httpClient.GetStringAsync(relativeUrl);

                if (response.Contains("erro"))
                    return new BaseResult<AddressDTO>(message: "cep não encontrado", success: false);

                AddressDTO address = JsonSerializer.Deserialize<AddressDTO>(response)!;

                return new BaseResult<AddressDTO>(address);
            }
        }
    }
}
