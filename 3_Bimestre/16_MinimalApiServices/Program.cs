using MinimalApiServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IClienteService, ClienteService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Configurar endpoints de Cliente
app.MapClienteEndpoints();

app.Run();
