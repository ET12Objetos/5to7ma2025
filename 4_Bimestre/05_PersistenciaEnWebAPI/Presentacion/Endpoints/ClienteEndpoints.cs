using Datos.Entidades;
using Dominio.DTOs;
using Dominio.Interfaces;

namespace Presentacion.Endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this WebApplication app)
    {
        app.MapGet("/clientes", (IClienteService clienteService) =>
        {
            return clienteService.GetAll();
        });

        app.MapGet("/clientes/{id}", (Guid id, IClienteService clienteService) =>
        {
            var cliente = clienteService.GetById(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        });

        app.MapPost("/clientes", (ClientePostDto clienteDto, IClienteService clienteService) =>
        {
            var nuevoCliente = clienteService.Create(clienteDto);

            return Results.Created($"/clientes/{nuevoCliente.Id}", nuevoCliente);
        });

        app.MapPut("/clientes/{id}", (Guid id, Cliente cliente, IClienteService clienteService) =>
        {
            var clienteActualizado = clienteService.Update(id, cliente);
            return clienteActualizado is not null ? Results.Ok(clienteActualizado) : Results.NotFound();
        });

        app.MapDelete("/clientes/{id}", (Guid id, IClienteService clienteService) =>
        {
            var eliminado = clienteService.Delete(id);
            return eliminado ? Results.NoContent() : Results.NotFound();
        });
    }
}
