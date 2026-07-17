using FinalTalabatProjectWebApis.Extentions;
using LinkDev.Talabat.Application;
using LinkDev.Talabat.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddControllers()
                .AddApplicationPart(typeof(Final.TalabatProject.WebApis.Controllers.AssemblyInformation).Assembly); // To add Part of Controllers of the onther layer

builder.Services.AddPersistenceServices(builder.Configuration);// Add Persistence Layer Services

builder.Services.AddApplicationServices();

//  Swagger Configuration
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion Configure Services

var app = builder.Build();

#region Update Database and Data seeding

await app.InitializeStoreContextAsync(); // Update All Pending Migrations and Seed Data in side Extenction Method to webApplication

#endregion Update Database and Data seeding

// Configure the HTTP request pipeline.

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion Middlewares

app.Run();