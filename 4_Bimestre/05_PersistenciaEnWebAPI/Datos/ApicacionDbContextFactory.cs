using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Datos;

public class ApicacionDbContextFactory : IDesignTimeDbContextFactory<AplicacionDbContext>
{
    public AplicacionDbContext CreateDbContext(string[] args)
    {
        var connectionString = "server=localhost;database=aplicacion;user=root;password=pass123";

        var options = new DbContextOptionsBuilder<AplicacionDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        return new AplicacionDbContext(options);
    }
}
