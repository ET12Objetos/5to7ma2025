namespace ValidacionesyCosasRandom;

public class Persona
{
    public string Nombre { get; set; }
    public string? Telefono { get; set; }

    public Persona(string nombre, string? telefono = null)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    //responsabilidad de la clase Persona
    public bool TieneTelefono()
    {
        return !string.IsNullOrEmpty(Telefono);
    }
}