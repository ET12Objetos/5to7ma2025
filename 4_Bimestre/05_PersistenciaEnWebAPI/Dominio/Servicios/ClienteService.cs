using Datos.Entidades;
using Datos.Interfaces;
using Dominio.DTOs;
using Dominio.Interfaces;

namespace Dominio.Servicios;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public Cliente Create(ClientePostDto clienteDto)
    {
        Cliente cliente = new Cliente();

        cliente.Nombre = clienteDto.Nombre;
        cliente.Email = clienteDto.Email;

        return clienteRepository.Crear(cliente);
    }

    public bool Delete(Guid id)
    {
        return clienteRepository.Eliminar(id);
    }

    public bool Exists(Guid id)
    {
        return clienteRepository.Existe(id);
    }

    public IEnumerable<Cliente> GetAll()
    {
        return clienteRepository.ObtenerTodos();
    }

    public Cliente? GetById(Guid id)
    {
        return clienteRepository.ObtenerPorId(id);
    }

    public Cliente? Update(Guid id, Cliente cliente)
    {
        return clienteRepository.Actualizar(cliente);
    }
}
