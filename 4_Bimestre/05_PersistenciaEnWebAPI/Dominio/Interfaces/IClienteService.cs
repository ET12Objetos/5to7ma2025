using Datos.Entidades;
using Dominio.DTOs;

namespace Dominio.Interfaces;

public interface IClienteService
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(Guid id);
    Cliente Create(ClientePostDto cliente);
    Cliente? Update(Guid id, Cliente cliente);
    bool Delete(Guid id);
    bool Exists(Guid id);
}
