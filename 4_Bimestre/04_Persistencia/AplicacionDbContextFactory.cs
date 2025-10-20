using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistencia;

public class AplicacionDbContextFactory : IDesignTimeDbContextFactory<AplicacionDbContext>
{
    public AplicacionDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AplicacionDbContext>();

        // Usar la misma cadena de conexión que tienes en Program.cs
        string connectionString = "server=localhost;database=hola;user=root;password=pass123";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new AplicacionDbContext(optionsBuilder.Options);
    }
}