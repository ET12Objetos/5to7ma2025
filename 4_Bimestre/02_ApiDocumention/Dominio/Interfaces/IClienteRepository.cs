using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IClienteRepository
{
    IEnumerable<Cliente> ObtenerTodos();
    Cliente? ObtenerPorId(int id);
    Cliente Crear(Cliente cliente);
    Cliente Actualizar(Cliente cliente);
    bool Eliminar(int id);
    bool Existe(int id);
}
