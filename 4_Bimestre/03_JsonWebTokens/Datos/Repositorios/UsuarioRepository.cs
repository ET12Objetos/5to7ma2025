using Dominio.Entidades;
using Dominio.Interfaces;

namespace Datos.Repositorios;

public class UsuarioRepository : IUsuarioRepository
{
    private static readonly List<Usuario> _usuarios = new()
    {
        new Usuario
        {
            Id = 1,
            Email = "admin@mail.com",
            Password = "pass123", // En producción usar hash
            Rol = "Admin"
        },
        new Usuario
        {
            Id = 2,
            Email = "usuario@mail.com",
            Password = "pass123", // En producción usar hash
            Rol = "User"
        }
    };

    public Usuario? GetByEmail(string email)
    {
        return _usuarios.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public Usuario Create(Usuario usuario)
    {
        var maxId = _usuarios.Any() ? _usuarios.Max(u => u.Id) : 0;
        usuario.Id = maxId + 1;
        _usuarios.Add(usuario);
        return usuario;
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _usuarios;
    }
}