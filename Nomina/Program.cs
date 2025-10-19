using Microsoft.EntityFrameworkCore;
using Nomina.API.Filters;
using Nomina.API.Middleware;
using Nomina.Application.interfaces;
using Nomina.Application.Services;
using Nomina.Domain.Interfaces;
using Nomina.Infrastructure.Persistence;
using Nomina.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Permite solicitudes de cualquier origen
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.

// Configurar cadena de conexión
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Inyección de dependencias
builder.Services.AddScoped<iTrabajadorRepository>(sp => new TrabajadorRepository(connectionString));
builder.Services.AddScoped<INominaRepository>(sp =>
{
    var context = sp.GetRequiredService<AppDbContext>();
    return new NominaRepository(context, connectionString);
});

builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<INominaService, NominaService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

//app.UseExceptionHandler("/error");

app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
