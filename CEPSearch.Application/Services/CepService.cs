using CEPSearch.Application.Interfaces;
using CEPSearch.Domain.DTOs.Responses;
using CEPSearch.InfraExternal.Interfaces;
using Microsoft.Extensions.Logging;
using Refit;
using System.Text.Json;

namespace CEPSearch.Application.Services
{
    public class CepService : ICepService
    {
        private readonly IViaCepExternalService _viaCepExternal;
        private readonly ILogger _logger;
        public CepService(IViaCepExternalService viaCepExternal, ILogger<CepService> logger)
        {
            _viaCepExternal = viaCepExternal;
            _logger = logger;
        }

        public async Task<CepResponse> GetAddressByCep(string cep)
        {
            try
            {
                var address = await _viaCepExternal.GetCep(cep);

                _logger.LogInformation(JsonSerializer.Serialize(address));

                return address;
            }
            catch(ApiException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.ReasonPhrase!);
            }
        }
    }
}
