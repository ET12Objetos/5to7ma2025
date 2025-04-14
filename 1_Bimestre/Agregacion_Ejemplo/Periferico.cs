namespace Agregacion_Ejemplo;

public class Periferico
{
    public string Nombre;
    public string Tipo;

    public Periferico(string nombre, string tipo)
    {
        Nombre = nombre;
        Tipo = tipo;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Tipo: {Tipo}");
    }
}