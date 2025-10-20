using Datos.Entidades;
using Datos.Interfaces;

namespace Datos.Repositorios;

public class ClienteRepository : IClienteRepository
{
    private readonly AplicacionDbContext context;

    public ClienteRepository(AplicacionDbContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<Cliente> ObtenerTodos()
    {
        return context.Clientes;
    }

    public Cliente? ObtenerPorId(Guid id)
    {
        return context.Clientes.FirstOrDefault(c => c.Id == id);
    }

    public Cliente Crear(Cliente cliente)
    {
        context.Clientes.Add(cliente);
        context.SaveChanges();
        return cliente;
    }

    public Cliente Actualizar(Cliente cliente)
    {
        var clienteExistente = context.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (clienteExistente != null)
        {
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Email = cliente.Email;
            context.SaveChanges();
        }
        return clienteExistente ?? cliente;
    }

    public bool Eliminar(Guid id)
    {
        var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Existe(Guid id)
    {
        return context.Clientes.Any(c => c.Id == id);
    }
}
