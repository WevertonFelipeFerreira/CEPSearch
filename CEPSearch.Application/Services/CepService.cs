using CEPSearch.Application.Interfaces;
using CEPSearch.Domain.DTOs.Responses;

namespace CEPSearch.Application.Services
{
    internal class CepService : ICepService
    {
        public CepService()
        {

        }

        public async Task<CepResponse> GetByCep(string cep)
        {
            throw new NotImplementedException();
        }
    }
}
