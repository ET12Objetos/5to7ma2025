using Dominio.Entidades;
using Dominio.Interfaces;

namespace Dominio.Servicios;

public class ClienteService : IClienteService
{
    private readonly List<Cliente> _clientes;

    public ClienteService()
    {
        _clientes = new List<Cliente>
        {
            new Cliente { Id = 0, Nombre = "Juan Pérez", Email = "juan.perez@email.com" },
            new Cliente { Id = 1, Nombre = "María García", Email = "maria.garcia@email.com" },
            new Cliente { Id = 2, Nombre = "Carlos López", Email = "carlos.lopez@email.com" }
        };
    }

    public IEnumerable<Cliente> GetAll()
    {
        return _clientes;
    }

    public Cliente? GetById(int id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public Cliente Create(Cliente cliente)
    {
        cliente.Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
        _clientes.Add(cliente);
        return cliente;
    }

    public Cliente? Update(int id, Cliente clienteActualizado)
    {
        var clienteExistente = _clientes.FirstOrDefault(c => c.Id == id);
        if (clienteExistente == null)
            return null;

        clienteExistente.Nombre = clienteActualizado.Nombre;
        clienteExistente.Email = clienteActualizado.Email;
        return clienteExistente;
    }

    public bool Delete(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return false;

        return _clientes.Remove(cliente);
    }

    public bool Exists(int id)
    {
        return _clientes.Any(c => c.Id == id);
    }
}
