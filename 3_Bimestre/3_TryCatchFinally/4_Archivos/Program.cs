// Ejemplo 4 - Archivos

try
{
    string contenido = File.ReadAllText("archivo.txt");
    Console.WriteLine(contenido);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine("Intento de lectura de archivo completado.");
}