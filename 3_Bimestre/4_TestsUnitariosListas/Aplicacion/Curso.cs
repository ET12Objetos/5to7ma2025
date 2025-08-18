namespace Aplicacion;

public class Curso
{
    public virtual string Nombre { get; set; }
    public virtual List<Alumno> Alumnos { get; set; }

    public Curso(string nombre)
    {
        Nombre = nombre;
        Alumnos = new List<Alumno>();
    }

    public virtual void AgregarAlumno(Alumno alumno)
    {
        Alumnos.Add(alumno);
    }
}