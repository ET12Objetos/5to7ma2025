using MinimalApiDelete;

var app = WebApplication.CreateBuilder(args).Build();

app.UseHttpsRedirection();

var clientes = new List<Cliente>
{
    new Cliente { Id = 1, Nombre = "Juan", Email = "jose@email.com" },
    new Cliente { Id = 2, Nombre = "Maria", Email = "marcela@email.com" },
    new Cliente { Id = 3, Nombre = "Jonathan", Email = "jonathan@email.com" }
};

app.MapGet("/clientes", () => clientes);

app.MapGet("/clientes/{id}", (int id) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    return cliente is not null ? Results.Ok(cliente) : Results.NotFound($"Cliente con ID {id} no encontrado.");
});

app.MapPost("/clientes", (Cliente cliente) =>
{
    cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});

app.MapDelete("/clientes/{id}", (int id) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);

    if (cliente == null)
    {
        return Results.NotFound($"Cliente con ID {id} no encontrado.");
    }

    clientes.Remove(cliente);
    return Results.Ok($"Cliente con ID {id} eliminado exitosamente.");
});

app.Run();