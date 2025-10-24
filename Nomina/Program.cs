using Microsoft.EntityFrameworkCore;
using Nomina.API.Filters;
using Nomina.API.Middleware;
using Nomina.Application.interfaces;
using Nomina.Application.Services;
using Nomina.Domain.Interfaces;
using Nomina.Infrastructure.Persistence;
using Nomina.Infrastructure.Repositories;
using QuestPDF.Infrastructure; 

var builder = WebApplication.CreateBuilder(args);


QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<iTrabajadorRepository>(sp => new TrabajadorRepository(connectionString));
builder.Services.AddScoped<IReporteNominaRepository, ReporteNominaRepository>(provider =>
    new ReporteNominaRepository(connectionString));
builder.Services.AddScoped<INominaRepository>(sp =>
{
    var context = sp.GetRequiredService<AppDbContext>();
    return new NominaRepository(context, connectionString);
});

builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<INominaService, NominaService>();

builder.Services.AddScoped<IReporteNominaService, ReporteNominaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseExceptionHandler("/error");

app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();