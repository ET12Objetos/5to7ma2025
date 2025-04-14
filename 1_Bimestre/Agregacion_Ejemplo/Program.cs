using Agregacion_Ejemplo;

Console.WriteLine("Ingrese los datos del periférico:");
Console.Write("Nombre: ");
string nombrePeriferico = Console.ReadLine();
Console.Write("Tipo: ");
string tipoPeriferico = Console.ReadLine();

Periferico periferico = new Periferico(nombrePeriferico, tipoPeriferico);

Console.WriteLine("\nIngrese los datos de la computadora:");
Console.Write("Marca: ");
string marcaComputadora = Console.ReadLine();
Console.Write("Modelo: ");
string modeloComputadora = Console.ReadLine();

Computadora computadora = new Computadora(marcaComputadora, modeloComputadora, periferico);

Console.WriteLine("\nInformación ingresada:");
computadora.MostrarEstado();