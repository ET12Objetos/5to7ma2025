using Datos.Entidades;
using Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Endpoints;

public static class ProveedorEndpoints
{
    public static void MapProveedorEndpoints(this WebApplication app)
    {
        app.MapGet("/api/proveedor", (IProveedorService proveedorService) =>
        {
            IEnumerable<Proveedor> proveedores = proveedorService.GetAll();

            return Results.Ok(proveedores);
        });

        app.MapGet("/api/proveedor/{id}", (Guid id, IProveedorService proveedorService) =>
      {
          Proveedor? proveedor = proveedorService.GetById(id);

          return Results.Ok(proveedor);
      });
    }
}