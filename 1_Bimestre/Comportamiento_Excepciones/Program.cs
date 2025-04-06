using Comportamiento_Excepciones;

//ingreso de datos
Console.Write("Ingrese modelo: ");
string modelo = Console.ReadLine();
Console.Write("Ingrese patente: ");
string patente = Console.ReadLine();

//creacion de objeto
Automovil automovil = new Automovil(patente, modelo);

//impresion de datos por consola
Console.WriteLine($"Patente: {automovil.Patente}");
Console.WriteLine($"Modelo: {automovil.Modelo}");

// Console.WriteLine($"Estado: {automovil.EstadoMotor}");

// //verificar si el automovil esta encendido o apagado
// automovil.Apagar();
// Console.WriteLine($"Estado: {automovil.EstadoMotor}");
// automovil.Arrancar();
// Console.WriteLine($"Estado: {automovil.EstadoMotor}");