using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades;

public class Cliente
{
    [Required(ErrorMessage = "El Id es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser mayor que cero.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es válido.")]
    public string Email { get; set; } = string.Empty;
}