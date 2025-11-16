using FluentValidation;
using Trailz.Api.Filters;
using Trailz.Core.Features.Reviews.Read;
using Trailz.Core.Features.Trails.Read;
using Trailz.Infrastructure;

namespace Trailz.Api.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddValidatorsFromAssemblyContaining<IInfrastructureAssemblyMarker>();

            services.AddTransient<TrailReadService>();
            services.AddTransient<ReviewReadService>();
            services.AddScoped<ValidationActionFilter<>>();

            return services;
        }
    }
}
