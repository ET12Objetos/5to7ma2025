using EjemploObjetos;

Lata lata1 = new Lata("Azul", 300);

Console.WriteLine($"Color: {lata1.Color}");
Console.WriteLine($"Contenido: {lata1.Contenido}");

lata1.Color = "";

lata1.Contenido = -19;

Console.WriteLine($"Color: {lata1.Color}");
Console.WriteLine($"Contenido: {lata1.Contenido}");


