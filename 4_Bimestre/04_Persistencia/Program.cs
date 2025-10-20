using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Entidades;

string connectionString = "server=localhost;database=hola;user=root;password=pass123";

var opciones = new DbContextOptionsBuilder<AplicacionDbContext>()
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .Options;

var contexto = new AplicacionDbContext(opciones);

//insertar alumnos 
// var alumno = new Alumno
// {
//     Nombre = "Mario",
//     Email = "mario@mail.com"
// };

// contexto.Alumnos.Add(alumno);
// contexto.Alumnos.Add(new Alumno { Nombre = "Juan", Email = "juan@mail.com" });

// contexto.SaveChanges();

//consultar alumnos
var alumnos = contexto.Alumnos.Where(a => a.Nombre.ToUpper().StartsWith("J"));

foreach (var alumno in alumnos)
{
    Console.WriteLine($"{alumno.Id} {alumno.Nombre} {alumno.Email}");
}
