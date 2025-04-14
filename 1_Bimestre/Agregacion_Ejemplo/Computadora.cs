namespace Agregacion_Ejemplo;

public class Computadora
{
    public string Marca;
    public string Modelo;

    //el periferico puede ser null
    //si no se conecta ningun periferico es null
    //con el caracter ? se indica que el tipo de dato puede ser null
    public Periferico? PerifericoConectado = null;

    public Computadora(string marca, string modelo, Periferico periferico)
    {
        Marca = marca;
        Modelo = modelo;
        PerifericoConectado = periferico;
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}");
        Console.WriteLine("Periféricos:");
        PerifericoConectado.MostrarInfo();
    }
}