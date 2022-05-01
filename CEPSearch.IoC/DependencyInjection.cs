using CEPSearch.Application.Interfaces;
using CEPSearch.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CEPSearch.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICepService, CepService>();

            return services;
        }
    }
}