using Dominio.Interfaces;
using Dominio.Servicios;
using Datos.Repositorios;
using Presentacion.Endpoints;
using Scalar.AspNetCore;
using Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de OpenApi (Obligatorio)
builder.Services.AddOpenApi();

//Configuración de Swagger
builder.Services.AddSwaggerGen();

// Configurar DbContext
var connectionString = builder.Configuration.GetConnectionString("aplicacion");

builder.Services.AddDbContext<Datos.AplicacionDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProveedorService, ProveedorService>();

var app = builder.Build();

app.UseHttpsRedirection();

//Configurar OpenApi (obligatorio)
app.MapOpenApi();

//Configurar Scalar (Opcional)
app.MapScalarApiReference();

//Configurar Swagger UI (Opcional)
app.UseSwagger();
app.UseSwaggerUI(x => x.EnableTryItOutByDefault());

// Configurar endpoints de Cliente
app.MapClienteEndpoints();
app.MapProveedorEndpoints();

app.Run();
