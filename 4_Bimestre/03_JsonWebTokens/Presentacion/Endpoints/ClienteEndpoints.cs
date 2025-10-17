using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Presentacion.Endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this WebApplication app)
    {
        app.MapGet("/clientes", [Authorize] (IClienteService clienteService) =>
        {
            return clienteService.GetAll();
        })
        .WithName("GetClientes")
        .WithSummary("Obtener todos los clientes")
        .WithDescription("Obtiene la lista de todos los clientes (requiere autenticación)");

        app.MapGet("/clientes/{id}", [Authorize] (int id, IClienteService clienteService) =>
        {
            var cliente = clienteService.GetById(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        })
        .WithName("GetClienteById")
        .WithSummary("Obtener cliente por ID")
        .WithDescription("Obtiene un cliente específico por su ID (requiere autenticación)");

        app.MapPost("/clientes", [Authorize] (Cliente cliente, IClienteService clienteService) =>
        {
            var nuevoCliente = clienteService.Create(cliente);
            return Results.Created($"/clientes/{nuevoCliente.Id}", nuevoCliente);
        })
        .WithName("CreateCliente")
        .WithSummary("Crear nuevo cliente")
        .WithDescription("Crea un nuevo cliente (requiere autenticación)");

        app.MapPut("/clientes/{id}", [Authorize] (int id, Cliente cliente, IClienteService clienteService) =>
        {
            var clienteActualizado = clienteService.Update(id, cliente);
            return clienteActualizado is not null ? Results.Ok(clienteActualizado) : Results.NotFound();
        })
        .WithName("UpdateCliente")
        .WithSummary("Actualizar cliente")
        .WithDescription("Actualiza un cliente existente (requiere autenticación)");

        app.MapDelete("/clientes/{id}", [Authorize(Roles = "Admin")] (int id, IClienteService clienteService) =>
        {
            var eliminado = clienteService.Delete(id);
            return eliminado ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteCliente")
        .WithSummary("Eliminar cliente")
        .WithDescription("Elimina un cliente (requiere rol de Admin)");
    }
}
