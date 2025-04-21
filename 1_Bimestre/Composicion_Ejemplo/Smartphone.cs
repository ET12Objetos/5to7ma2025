namespace EjemploComposicion;

// public class Smartphone
// {
//     public string modelo;

//     public Bateria bateria;

//     public Chip chip;

//     public Smartphone(string modelo, Chip chip)
//     {
//         this.modelo = modelo;
//         this.chip = chip;
//         this.bateria = new Bateria(4000, "Samsung");
//     }

//     public void Informar()
//         => Console.WriteLine($"Modelo: {modelo}, Marca: {bateria.marca}, Chip: {chip.numero}");
// }

// public class Smartphone
// {
//     public string modelo;

//     public Bateria bateria;

//     public Chip chip;

//     public Smartphone(string modelo, Chip chip, string modeloBateria, int capacidadBateria)
//     {
//         this.modelo = modelo;
//         this.chip = chip;
//         this.bateria = new Bateria(capacidadBateria, modeloBateria);
//     }

//     public void Informar()
//         => Console.WriteLine($"Modelo: {modelo}, Marca: {bateria.marca}, Chip: {chip.numero}");
// }

public class Smartphone
{
    public string modelo;

    public Bateria bateria;

    public Chip chip;

    public Smartphone(string modelo)
    {
        this.modelo = modelo;
    }

    public void AgregarChip(Chip chip)
    {
        this.chip = chip;
    }   

    public void AgregarBateria(string modeloBateria, int capacidadBateria)
    {
        this.bateria = new Bateria(capacidadBateria, modeloBateria);
    }

    public void Informar()
        => Console.WriteLine($"Modelo: {modelo}, Marca: {bateria.marca}, Chip: {chip.numero}");
}
