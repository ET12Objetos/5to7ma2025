using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades;

public class Usuario
{
    [Required(ErrorMessage = "El Id es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser mayor que cero.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string Password { get; set; } = string.Empty;

    public string Rol { get; set; } = "User";
}