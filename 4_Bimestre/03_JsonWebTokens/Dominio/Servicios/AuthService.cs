using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Dominio.Servicios;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public AuthService(IUsuarioRepository usuarioRepository, string secretKey, string issuer, string audience)
    {
        _usuarioRepository = usuarioRepository;
        _secretKey = secretKey;
        _issuer = issuer;
        _audience = audience;
    }

    public string GenerateJwtToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public LoginResponse? Login(LoginRequest request)
    {
        var usuario = _usuarioRepository.GetByEmail(request.Email);

        if (usuario == null || !ValidatePassword(request.Password, usuario.Password))
        {
            return null;
        }

        var token = GenerateJwtToken(usuario);

        return new LoginResponse
        {
            Token = token,
            Email = usuario.Email,
            Rol = usuario.Rol
        };
    }

    public Usuario? Register(RegisterRequest request)
    {
        // Verificar si el usuario ya existe
        if (_usuarioRepository.GetByEmail(request.Email) != null)
        {
            return null;
        }

        var usuario = new Usuario
        {
            Email = request.Email,
            Password = HashPassword(request.Password),
            Rol = "User"
        };

        return _usuarioRepository.Create(usuario);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        // Para simplicidad, usaremos comparación simple de texto
        // En producción, deberías usar BCrypt u otro algoritmo de hash
        return password == hashedPassword || HashPassword(password) == hashedPassword;
    }

    public string HashPassword(string password)
    {
        // Para simplicidad, usaremos Base64
        // En producción, deberías usar BCrypt u otro algoritmo de hash
        var bytes = Encoding.UTF8.GetBytes(password + "salt");
        return Convert.ToBase64String(bytes);
    }
}