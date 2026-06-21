using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace LinkDev.Talabat.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("StoreContext") ??
            throw new InvalidOperationException("Connection String ' storeContext ' is not found ");

        services.AddDbContext<StoreContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString(connectionString));
        });

        return services;
    }
}