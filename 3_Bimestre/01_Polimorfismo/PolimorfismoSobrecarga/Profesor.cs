namespace PolimorfismoSobrecarga;

public class Profesor
{
    public int Edad { get; set; }
    public string Nombre { get; set; }

    public Profesor(string Nombre, int Edad = 0)
    {
        this.Nombre = Nombre;
        this.Edad = Edad;
    }

    public string ObtenerDescripcion()
    {
        return $"Hola Mundo";
    }
}