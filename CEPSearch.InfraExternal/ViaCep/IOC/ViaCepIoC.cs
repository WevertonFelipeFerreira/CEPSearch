using CEPSearch.InfraExternal.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Microsoft.Extensions.Configuration;

namespace CEPSearch.InfraExternal.ViaCep.IOC
{
    public static class ViaCepIoC
    {
        public static IServiceCollection AddViaCep(this IServiceCollection services, IConfiguration cfg)
        {
            var viaCepBaseUrl = cfg["ViaCepBaseUrl"].ToString();

            services.AddRefitClient<IViaCepExternalService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(viaCepBaseUrl));

            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }
    }
}
