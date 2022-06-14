using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ApiDDD.Data;

namespace ApiDDD.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FactoryContext>(options =>
                        options.UseSqlServer(GetApiConnectionString(configuration))
                        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));
        }

        public static string GetApiConnectionString(IConfiguration configuration)
            => configuration.GetConnectionString("DataDev");
    }
}