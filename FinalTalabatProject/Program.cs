using LinkDev.Talabat.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DI Container

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);// Add Persistence Layer Services

builder.Services.AddSwaggerGen(); // swagger

#endregion DI Container

var app = builder.Build();

// Configure the HTTP request pipeline.

#region Middlewares

// Configure the HTTP request pipeline.
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