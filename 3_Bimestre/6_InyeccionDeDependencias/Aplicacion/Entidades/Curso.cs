namespace Aplicacion.Entidades;

public class Curso
{
    public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
    public Profesor Profesor { get; set; }
    public Curso(Profesor profesor)
    {
        Profesor = profesor;
    }
    public void AgregarAlumno(Alumno alumno)
    {
        Alumnos.Add(alumno);
    }
}