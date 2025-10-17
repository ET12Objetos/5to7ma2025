using Dominio.Entidades;
using Dominio.Interfaces;

namespace Presentacion.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/auth/login", (LoginRequest request, IAuthService authService) =>
        {
            var response = authService.Login(request);
            return response is not null ? Results.Ok(response) : Results.Unauthorized();
        })
        .WithName("Login")
        .WithSummary("Iniciar sesión")
        .WithDescription("Autenticar usuario y obtener token JWT");

        app.MapPost("/auth/register", (RegisterRequest request, IAuthService authService) =>
        {
            var usuario = authService.Register(request);
            return usuario is not null ?
                Results.Created($"/usuarios/{usuario.Id}", new
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Rol = usuario.Rol
                }) :
                Results.BadRequest("El usuario ya existe");
        })
        .WithName("Register")
        .WithSummary("Registrar usuario")
        .WithDescription("Crear nuevo usuario en el sistema");
    }
}