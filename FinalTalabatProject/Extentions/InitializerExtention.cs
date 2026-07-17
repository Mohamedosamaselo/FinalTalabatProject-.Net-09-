using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;
using LinkDev.Talabat.Persistence._Data;

namespace FinalTalabatProjectWebApis.Extentions;

public static class InitializerExtention
{
    public static async Task InitializeStoreContextAsync(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateAsyncScope();

        var service = scope.ServiceProvider;

        var dbContextInitializer = service.GetRequiredService<IStoreContextInitilazer>(); //ask Clr for an object from "StoreContextInitializer"  Service Explicitly [DI Explicitly way ]

        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            await dbContextInitializer.InitilizeAsync();

            await dbContextInitializer.SeedAsync();
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogError(ex,
                             "An error occurred during Migrations or the data seeding ."
                );
        }
    }
}