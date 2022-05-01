using CEPSearch.Domain.DTOs.Responses;

namespace CEPSearch.Application.Interfaces
{
    public interface ICepService
    {
        Task<CepResponse> GetByCep(string cep);
    }
}
