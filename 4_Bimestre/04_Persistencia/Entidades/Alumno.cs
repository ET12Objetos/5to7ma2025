using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia.Entidades;

[Table("Alumno")]
public class Alumno
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Nombre { get; set; } = default!;


    public string Email { get; set; } = default!;
}