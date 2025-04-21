namespace EjemploListas;

public class Producto
{
    public string Nombre;
    public decimal Precio;
    public bool EnStock;

    public Producto(string nombre, decimal precio, bool enStock)
    {
        Nombre = nombre;
        Precio = precio;
        EnStock = enStock;
    }
}