using Datos.Entidades;

namespace Datos.Interfaces;

public interface IClienteRepository
{
    IEnumerable<Cliente> ObtenerTodos();
    Cliente? ObtenerPorId(Guid id);
    Cliente Crear(Cliente cliente);
    Cliente Actualizar(Cliente cliente);
    bool Eliminar(Guid id);
    bool Existe(Guid id);
}
