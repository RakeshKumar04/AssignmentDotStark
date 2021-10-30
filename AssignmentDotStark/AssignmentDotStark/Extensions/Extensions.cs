using AssignmentDotStark.Contracts;
using AssignmentDotStark.Infrastructure;
using AssignmentDotStark.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AssignmentDotStark.Extensions
{
    public static class ServiceExtension
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("MSSQL");
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);
            var commandTimeout = (int)TimeSpan.FromMinutes(20).TotalSeconds;

            services.AddDbContextPool<DatabaseContext>(o =>
            {
                o.UseSqlServer(connectionString, sqlOpt => sqlOpt.CommandTimeout(commandTimeout));
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
