using Microsoft.AspNetCore.Mvc;
using MinimalApiGet;

var app = WebApplication.CreateBuilder(args).Build();

app.UseHttpsRedirection();

var clientes = new List<Cliente>
{
    new Cliente { Id = 1, Nombre = "Juan", Email = "jose@email.com" },
    new Cliente { Id = 2, Nombre = "Maria", Email = "marcela@email.com" },
    new Cliente { Id = 3, Nombre = "Jonathan", Email = "jonathan@email.com" }
};

app.MapGet("/clientes/{id:int}", ([FromRoute] int id) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    return cliente is null ? Results.NotFound() : Results.Ok(cliente);
});

app.MapGet("/clientes", ([FromQuery] string? nombre) =>
{
    if (string.IsNullOrWhiteSpace(nombre))
        return Results.Ok(clientes);

    var cliente = clientes.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    return cliente is null ? Results.NotFound() : Results.Ok(cliente);
});

app.Run();

