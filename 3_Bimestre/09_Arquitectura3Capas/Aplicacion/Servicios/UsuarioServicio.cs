using Dominio.Entidades;
using Dominio.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacion.Servicios
{
    public class UsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario? ObtenerUsuarioPorId(int id)
        {
            return _usuarioRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepositorio.ObtenerTodos();
        }

        public Usuario CrearUsuario(string nombre, string apellido, string email, string nombreUsuario, string password)
        {
            // Validaciones
            if (_usuarioRepositorio.ExisteEmail(email))
                throw new InvalidOperationException("El email ya está en uso");

            if (_usuarioRepositorio.ExisteNombreUsuario(nombreUsuario))
                throw new InvalidOperationException("El nombre de usuario ya está en uso");

            var usuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                NombreUsuario = nombreUsuario,
                PasswordHash = HashPassword(password),
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            return _usuarioRepositorio.Crear(usuario);
        }

        public bool ValidarCredenciales(string nombreUsuario, string password)
        {
            var usuario = _usuarioRepositorio.ObtenerPorNombreUsuario(nombreUsuario);
            if (usuario == null || !usuario.Activo)
                return false;

            return VerificarPassword(password, usuario.PasswordHash);
        }

        public Usuario? ActualizarUsuario(int id, string nombre, string apellido, string email)
        {
            var usuario = _usuarioRepositorio.ObtenerPorId(id);
            if (usuario == null)
                return null;

            // Verificar si el email ya existe en otro usuario
            var usuarioConEmail = _usuarioRepositorio.ObtenerPorEmail(email);
            if (usuarioConEmail != null && usuarioConEmail.Id != id)
                throw new InvalidOperationException("El email ya está en uso por otro usuario");

            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Email = email;

            return _usuarioRepositorio.Actualizar(usuario);
        }

        public bool CambiarPassword(int id, string passwordActual, string nuevoPassword)
        {
            var usuario = _usuarioRepositorio.ObtenerPorId(id);
            if (usuario == null)
                return false;

            if (!VerificarPassword(passwordActual, usuario.PasswordHash))
                return false;

            usuario.PasswordHash = HashPassword(nuevoPassword);
            _usuarioRepositorio.Actualizar(usuario);
            return true;
        }

        public bool ActivarUsuario(int id)
        {
            return _usuarioRepositorio.ActivarUsuario(id);
        }

        public bool DesactivarUsuario(int id)
        {
            return _usuarioRepositorio.DesactivarUsuario(id);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerificarPassword(string password, string hash)
        {
            var hashedPassword = HashPassword(password);
            return hashedPassword == hash;
        }
    }
}
