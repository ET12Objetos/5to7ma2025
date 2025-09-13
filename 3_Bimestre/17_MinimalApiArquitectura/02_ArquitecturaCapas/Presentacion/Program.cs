using Dominio.Interfaces;
using Dominio.Servicios;
using Datos.Repositorios;
using Presentacion.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Configurar endpoints de Cliente
app.MapClienteEndpoints();

app.Run();
