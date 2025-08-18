namespace Aplicacion;

public class Alumno
{
    public string? Nombre { get; set; }
    public int Nota { get; set; }
    public Alumno(string nombre, int nota)
    {
        Nombre = nombre;
        Nota = nota;
    }
}