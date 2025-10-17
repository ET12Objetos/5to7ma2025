using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(Usuario usuario);
    LoginResponse? Login(LoginRequest request);
    Usuario? Register(RegisterRequest request);
    bool ValidatePassword(string password, string hashedPassword);
    string HashPassword(string password);
}