using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario? ObtenerPorId(int id);
        Usuario? ObtenerPorEmail(string email);
        Usuario? ObtenerPorNombreUsuario(string nombreUsuario);
        IEnumerable<Usuario> ObtenerTodos();
        Usuario Crear(Usuario usuario);
        Usuario Actualizar(Usuario usuario);
        bool Eliminar(int id);
        bool ExisteEmail(string email);
        bool ExisteNombreUsuario(string nombreUsuario);
        bool ActivarUsuario(int id);
        bool DesactivarUsuario(int id);
    }
}
