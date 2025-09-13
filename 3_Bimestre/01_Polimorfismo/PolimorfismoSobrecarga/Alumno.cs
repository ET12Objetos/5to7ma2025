namespace PolimorfismoSobrecarga;

public class Alumno
{
    public int Edad { get; set; }
    public string Nombre { get; set; }

    public Alumno(string Nombre, int Edad = 0)
    {
        this.Nombre = Nombre;
        this.Edad = Edad;
    }

    public string ObtenerDescripcion(Alumno alumno)
    {
        return $"Alumno: {alumno.Nombre}, Edad: {alumno.Edad}";
    }

    public string ObtenerDescripcion()
    {
        return $"Alumno: {Nombre}, Edad: {Edad}";
    }

    public string ObtenerDescripcion(string nombre, int edad)
    {
        return $"Alumno: {nombre}, Edad: {edad}";
    }
}