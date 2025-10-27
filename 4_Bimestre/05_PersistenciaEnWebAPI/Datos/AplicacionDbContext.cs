using Datos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public class AplicacionDbContext : DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Proveedor> Proveedores => Set<Proveedor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
