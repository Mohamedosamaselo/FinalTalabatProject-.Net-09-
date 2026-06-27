using FinalTalabatProjectWebApis.Extentions;
using LinkDev.Talabat.Application;
using LinkDev.Talabat.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);// Add Persistence Layer Services

builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion Configure Services

var app = builder.Build();

#region Update Database and Data seeding

await app.InitializeStoreContextAsync(); // Update All Pending Migrations and Seed Data in side Extenction Method to webApplication

#endregion Update Database and Data seeding

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