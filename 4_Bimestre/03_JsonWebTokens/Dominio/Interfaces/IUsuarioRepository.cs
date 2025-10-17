using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IUsuarioRepository
{
    Usuario? GetByEmail(string email);
    Usuario Create(Usuario usuario);
    IEnumerable<Usuario> GetAll();
}