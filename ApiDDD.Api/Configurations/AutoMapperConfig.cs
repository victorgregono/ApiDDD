using Microsoft.Extensions.DependencyInjection;
using ApiDDD.Application.Profiles;
using System.Reflection;

namespace ApiDDD.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
    }
}