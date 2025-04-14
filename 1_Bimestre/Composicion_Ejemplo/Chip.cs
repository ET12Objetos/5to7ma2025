namespace EjemploComposicion;

public class Chip
{
    public string operadora;
    public string numero;

    public Chip(string operadora, string numero)
    {
        this.operadora = operadora;
        this.numero = numero;
    }

    public void Informar()
        => Console.WriteLine($"Chip: {operadora}, Numero: {numero}");
}