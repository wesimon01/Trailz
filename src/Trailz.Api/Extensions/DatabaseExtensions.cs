using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trailz.Api.Configuration;
using Trailz.Infrastructure.Database;

namespace Trailz.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {         
            services.AddDbContext<TrailzDbContext>((serviceProvider, options) =>
            {
                var dbOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                options.UseSqlServer(dbOptions.ConnectionString, sqlServerOpts =>
                {
                    sqlServerOpts.CommandTimeout(dbOptions.CommandTimeout);
                    sqlServerOpts.EnableRetryOnFailure(dbOptions.MaxRetryCount);
                });
            });

            return services;
        }

    }
}
