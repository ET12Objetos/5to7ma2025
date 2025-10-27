using Datos.Entidades;

namespace Datos.Repositorios;

public interface IProveedorRepository
{
    IEnumerable<Proveedor> ObtenerTodos();
    Proveedor? ObtenerPorId(Guid id);
    Proveedor Crear(Proveedor proveedor);
    Proveedor Actualizar(Guid id, Proveedor proveedor);
    void Eliminar(Guid id);
}

public class ProveedorRepository : IProveedorRepository
{
    private readonly AplicacionDbContext context;
    public ProveedorRepository(AplicacionDbContext context)
    {
        this.context = context;

    }

    public Proveedor Actualizar(Guid id, Proveedor proveedor)
    {
        throw new NotImplementedException();
    }

    public Proveedor Crear(Proveedor proveedor)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(Guid id)
    {
        throw new NotImplementedException();
    }

    public Proveedor? ObtenerPorId(Guid id)
    {
        return context.Proveedores.SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<Proveedor> ObtenerTodos()
    {
        return context.Proveedores.ToList();
    }
}