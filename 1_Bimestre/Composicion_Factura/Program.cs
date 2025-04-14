using Composicion_Factura;

Console.WriteLine("Ingreso de datos de la factura");
Console.Write("Ingrese el número de la factura: ");
int numeroFactura = int.Parse(Console.ReadLine()!);
Console.Write("Ingrese el monto total de la factura: ");
decimal montoTotal = decimal.Parse(Console.ReadLine()!);

Factura factura = new Factura(numeroFactura, montoTotal);
factura.MostrarFactura();
Console.WriteLine("Factura creada con éxito.");