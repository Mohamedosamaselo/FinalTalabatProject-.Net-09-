using LinkDev.Talabat.Persistence;
using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);// Add Persistence Layer Services

#endregion Configure Services

var app = builder.Build();

#region Update database

using var scope = app.Services.CreateAsyncScope();// 01 create scpoe
var service = scope.ServiceProvider;//02 get the service provider from the scope to ask for the StoreContext instance
var context = service.GetRequiredService<StoreContext>();//03 Ask clr for the scoped instance of StoreContext explicitly

var loggerFactory = service.GetRequiredService<ILoggerFactory>();//04 get the logger factory to create a logger instance
try
{
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations != null)
        await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();

    logger.LogError(ex,
                     "An error occurred during application initialization."
        );
}

#endregion Update database

// Configure the HTTP request pipeline.

#region Middlewares

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion Middlewares

app.Run();