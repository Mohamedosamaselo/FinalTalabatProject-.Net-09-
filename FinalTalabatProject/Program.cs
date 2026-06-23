using LinkDev.Talabat.Persistence;
using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);// Add Persistence Layer Services

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion Configure Services

var app = builder.Build();

#region Update database and seed data

using var scope = app.Services.CreateAsyncScope();

var service = scope.ServiceProvider;

var context = service.GetRequiredService<StoreContext>();

var loggerFactory = service.GetRequiredService<ILoggerFactory>();

try
{
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations.Any())
        await context.Database.MigrateAsync();

    // seed data
    await StoreContextSeed.SeedAsync(context, loggerFactory);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();

    logger.LogError(ex,
                     "An error occurred during Migrations or the data seeding ."
        );
}

#endregion Update database and seed data

// Configure the HTTP request pipeline.

#region Middlewares

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#endregion Middlewares

app.Run();