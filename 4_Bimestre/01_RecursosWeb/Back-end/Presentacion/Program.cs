using Dominio.Interfaces;
using Dominio.Servicios;
using Datos.Repositorios;
using Presentacion.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Configurar endpoints de Cliente
app.MapClienteEndpoints();

app.Run();
