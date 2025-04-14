namespace Composicion_Factura;

public class Factura
{
    public int Numero;
    public decimal MontoTotal;
    public Cliente ClienteAsociado;
    
    public Factura(int numero, decimal montoTotal)
    {
        Numero = numero;
        MontoTotal = montoTotal;
        ClienteAsociado = new Cliente("Juan Perez", 12345678);
    }

    public void MostrarFactura()
    {
        Console.WriteLine($"Factura N°: {Numero}");
        Console.WriteLine($"Monto Total: ${MontoTotal}");
        Console.WriteLine($"Cliente: {ClienteAsociado.Nombre} (DNI: {ClienteAsociado.Dni})");
    }
}