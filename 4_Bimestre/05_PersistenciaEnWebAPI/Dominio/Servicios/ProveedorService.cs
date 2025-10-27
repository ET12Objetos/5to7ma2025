using Datos.Entidades;
using Datos.Repositorios;

namespace Dominio.Servicios;

public interface IProveedorService
{
    IEnumerable<Proveedor> GetAll();
    Proveedor? GetById(Guid id);
    Proveedor Create(Proveedor proveedor);
    Proveedor? Update(Guid id, Proveedor cliente);
    bool Delete(Guid id);
}

public class ProveedorService : IProveedorService
{
    private readonly IProveedorRepository proveedorRepository;

    public ProveedorService(IProveedorRepository proveedorRepository)
    {
        this.proveedorRepository = proveedorRepository;
    }

    public Proveedor Create(Proveedor proveedor)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Proveedor> GetAll()
    {
        return proveedorRepository.ObtenerTodos();
    }

    public Proveedor? GetById(Guid id)
    {
        return proveedorRepository.ObtenerPorId(id);
    }

    public Proveedor? Update(Guid id, Proveedor cliente)
    {
        throw new NotImplementedException();
    }
}