using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Common.Mapping;
using LinkDev.Talabat.Application.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Application;

public static class DependecyInjection

{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Option 1: Add profile instance
        services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));

        services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));

        return services;
    }
}