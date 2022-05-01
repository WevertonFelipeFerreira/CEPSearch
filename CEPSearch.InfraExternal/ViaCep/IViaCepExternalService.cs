using CEPSearch.Domain.DTOs.Responses;
using Refit;

namespace CEPSearch.InfraExternal.Interfaces
{
    public interface IViaCepExternalService
    {
        [Get("/ws/{cep}/json/")]
        Task<CepResponse> GetCep([AliasAs("cep")] string cep);
    }
}
