using Microsoft.Extensions.DependencyInjection;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Application.Interfaces;
using ApiDDD.Services;
using ApiDDD.Data.Repositories;


namespace ApiDDD.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Repository
            services.AddScoped<IVtexPromocoesRepository, VtexPromocoesRepository>();



            //Service
            services.AddScoped<IVtexPromocoesService, VtexPromocoesService>();

        }
    }
}
