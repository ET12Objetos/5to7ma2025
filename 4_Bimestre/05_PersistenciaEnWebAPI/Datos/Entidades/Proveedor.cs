using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.Entidades;

[Table("Proveedor")]
public class Proveedor
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = default!;
}