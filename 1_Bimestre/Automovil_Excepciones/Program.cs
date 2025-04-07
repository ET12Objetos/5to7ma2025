using Automovil_Excepciones;

Console.Write("Ingrese modelo: ");
string modelo = Console.ReadLine();
Console.Write("Ingrese patente: ");
string patente = Console.ReadLine();

Automovil automovil = new Automovil(patente, modelo);

Console.WriteLine($"Patente: {automovil.Patente}");
Console.WriteLine($"Modelo: {automovil.Modelo}");
