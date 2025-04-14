namespace EjemploComposicion;

public class Bateria
{
    public int mAh;

    public string marca;

    public Bateria(int mAh, string marca)
    {
        this.mAh = mAh;
        this.marca = marca;
    }

    public void Informar()
        => Console.WriteLine($"Bateria: {mAh} mAh, Marca: {marca}");
}