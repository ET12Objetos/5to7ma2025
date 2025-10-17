using Dominio.Entidades;
using Dominio.Interfaces;

namespace Datos.Repositorios;

public class ClienteRepository : IClienteRepository
{
    private static readonly List<Cliente> _clientes = new()
    {
        new Cliente { Id = 1, Nombre = "Juan Pérez", Email = "juan.perez@email.com" },
        new Cliente { Id = 2, Nombre = "María García", Email = "maria.garcia@email.com" },
        new Cliente { Id = 3, Nombre = "Carlos López", Email = "carlos.lopez@email.com" }
    };
    private static int _siguienteId = 4;

    public IEnumerable<Cliente> ObtenerTodos()
    {
        return _clientes;
    }

    public Cliente? ObtenerPorId(int id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public Cliente Crear(Cliente cliente)
    {
        cliente.Id = _siguienteId++;
        _clientes.Add(cliente);
        return cliente;
    }

    public Cliente Actualizar(Cliente cliente)
    {
        var clienteExistente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (clienteExistente != null)
        {
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Email = cliente.Email;
        }
        return clienteExistente ?? cliente;
    }

    public bool Eliminar(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            _clientes.Remove(cliente);
            return true;
        }
        return false;
    }

    public bool Existe(int id)
    {
        return _clientes.Any(c => c.Id == id);
    }
}
