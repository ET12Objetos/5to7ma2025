namespace EjemploComposicion;

public class Smartphone
{
    public string modelo;

    public Bateria bateria;

    public Chip chip;

    public Smartphone(string modelo, Chip chip)
    {
        this.modelo = modelo;
        this.chip = chip;
        this.bateria = new Bateria(4000, "Samsung");
    }

    public void Informar()
        => Console.WriteLine($"Modelo: {modelo}, Marca: {bateria.marca}, Chip: {chip.numero}");
}