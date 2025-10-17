using Dominio.Interfaces;
using Dominio.Servicios;
using Datos.Repositorios;
using Presentacion.Endpoints;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Configuración de OpenApi (Obligatorio)
builder.Services.AddOpenApi();

//Configuración de Swagger
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

// Configurar Swagger unicamente en desarrollo
// if (app.Environment.IsDevelopment())
// {
// }

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

app.Run();
