using Automovil_Composicion;

Console.Write("Ingrese modelo: ");
string modelo = Console.ReadLine();
Console.Write("Ingrese patente: ");
string patente = Console.ReadLine();

Automovil automovil = new Automovil(patente, modelo, motor: new Motor("ModeloMotor", "TipoMotor", 100, 200));

Console.WriteLine($"Patente: {automovil.Patente}");
Console.WriteLine($"Modelo: {automovil.Modelo}");
