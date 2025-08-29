using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // En una implementación real, aquí tendríamos el contexto de base de datos
        private readonly List<Usuario> _usuarios = new();

        public Usuario? ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            return _usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return _usuarios.ToList();
        }

        public Usuario Crear(Usuario usuario)
        {
            usuario.Id = _usuarios.Count > 0 ? _usuarios.Max(u => u.Id) + 1 : 1;
            usuario.FechaCreacion = DateTime.UtcNow;
            _usuarios.Add(usuario);
            return usuario;
        }

        public Usuario Actualizar(Usuario usuario)
        {
            var existente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existente != null)
            {
                existente.Nombre = usuario.Nombre;
                existente.Apellido = usuario.Apellido;
                existente.Email = usuario.Email;
                existente.NombreUsuario = usuario.NombreUsuario;
                existente.Activo = usuario.Activo;
            }
            return existente ?? usuario;
        }

        public bool Eliminar(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
                return true;
            }
            return false;
        }

        public bool ExisteEmail(string email)
        {
            return _usuarios.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            return _usuarios.Any(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public bool ActivarUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.Activo = true;
                return true;
            }
            return false;
        }

        public bool DesactivarUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.Activo = false;
                return true;
            }
            return false;
        }
    }
}
