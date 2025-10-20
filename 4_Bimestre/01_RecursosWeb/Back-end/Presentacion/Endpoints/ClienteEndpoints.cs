using Dominio.Entidades;
using Dominio.Interfaces;

namespace Presentacion.Endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this WebApplication app)
    {
        app.MapGet("/api/clientes", (IClienteService clienteService) =>
        {
            return clienteService.GetAll();
        });

        app.MapGet("/api/clientes/{id}", (int id, IClienteService clienteService) =>
        {
            var cliente = clienteService.GetById(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        });

        app.MapPost("/api/clientes", (Cliente cliente, IClienteService clienteService) =>
        {
            var nuevoCliente = clienteService.Create(cliente);
            return Results.Created($"/api/clientes/{nuevoCliente.Id}", nuevoCliente);
        });

        app.MapPut("/api/clientes/{id}", (int id, Cliente cliente, IClienteService clienteService) =>
        {
            var clienteActualizado = clienteService.Update(id, cliente);
            return clienteActualizado is not null ? Results.Ok(clienteActualizado) : Results.NotFound();
        });

        app.MapDelete("/api/clientes/{id}", (int id, IClienteService clienteService) =>
        {
            var eliminado = clienteService.Delete(id);
            return eliminado ? Results.NoContent() : Results.NotFound();
        });
    }
}
