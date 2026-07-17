using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;
using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("StoreContext") ?? throw new InvalidOperationException("Connection string 'StoreContext' not found.");

        services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IStoreContextInitilazer, StoreContextInitializer>();

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        return services;
    }
}