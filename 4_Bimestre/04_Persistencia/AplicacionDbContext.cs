using Microsoft.EntityFrameworkCore;
using Persistencia.Entidades;

namespace Persistencia;

public class AplicacionDbContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }

    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
        : base(opciones)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}