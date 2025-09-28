using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trailz.Api.Configuration;
using Trailz.Core.Features.Reviews.Read;
using Trailz.Core.Features.Trails.Read;
using Trailz.Infrastructure;
using Trailz.Infrastructure.Database;

namespace Trailz.Api.Extensions;

public static class IServiceCollectionExtensions
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
    
    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection("Database"))
            .ValidateDataAnnotations();

        return services;
    }
    
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IInfrastructureAssemblyMarker>();

        services.AddTransient<TrailReadService>();
        services.AddTransient<ReviewReadService>();

        return services;
    }
}