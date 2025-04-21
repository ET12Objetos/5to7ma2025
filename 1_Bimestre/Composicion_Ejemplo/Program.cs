// using EjemploComposicion;

// Console.WriteLine("Ingrese los datos del chip:");
// Console.Write("Operadora: ");
// string operadora = Console.ReadLine();
// Console.Write("Número: ");
// string numero = Console.ReadLine();

// Chip chip = new Chip(operadora, numero);

// Console.WriteLine("\nIngrese los datos del smartphone:");
// Console.Write("Modelo: ");
// string modelo = Console.ReadLine();

// Smartphone smartphone = new Smartphone(modelo, chip);

// Console.WriteLine("\nDatos del smartphone:");
// Console.WriteLine(smartphone);

// using EjemploComposicion;

// Console.WriteLine("Ingrese los datos del chip:");
// Console.Write("Operadora: ");
// string operadora = Console.ReadLine();
// Console.Write("Número: ");
// string numero = Console.ReadLine();

// Chip chip = new Chip(operadora, numero);

// Console.Write("Modelo de la batería: ");
// string modeloBateria = Console.ReadLine();
// Console.Write("Capacidad de la batería: ");
// int capacidadBateria = int.Parse(Console.ReadLine());

// Console.WriteLine("\nIngrese los datos del smartphone:");
// Console.Write("Modelo: ");
// string modelo = Console.ReadLine();

// Smartphone smartphone = new Smartphone(modelo, chip, modeloBateria, capacidadBateria);

// Console.WriteLine("\nDatos del smartphone:");
// Console.WriteLine(smartphone);

using EjemploComposicion;

Console.WriteLine("Ingrese los datos del chip:");
Console.Write("Operadora: ");
string operadora = Console.ReadLine();
Console.Write("Número: ");
string numero = Console.ReadLine();

Chip chip = new Chip(operadora, numero);

Console.Write("Modelo de la batería: ");
string modeloBateria = Console.ReadLine();
Console.Write("Capacidad de la batería: ");
int capacidadBateria = int.Parse(Console.ReadLine());

Console.WriteLine("\nIngrese los datos del smartphone:");
Console.Write("Modelo: ");
string modelo = Console.ReadLine();

Smartphone smartphone = new Smartphone(modelo);

smartphone.AgregarChip(chip);

smartphone.AgregarBateria(modeloBateria, capacidadBateria);

Console.WriteLine("\nDatos del smartphone:");
Console.WriteLine(smartphone);