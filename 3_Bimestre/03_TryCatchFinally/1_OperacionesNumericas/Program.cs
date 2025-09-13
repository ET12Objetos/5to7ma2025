//Ejemplo 1 - Operaciones División por Cero
try
{
    int numerador = 10;
    int denominador = 0;
    int resultado = numerador / denominador;
    Console.WriteLine($"Resultado: {resultado}");
}
catch (ArgumentException ex)
{
    System.Console.WriteLine(ex.ToString());
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Mensaje error: {ex.Message}");
    System.Console.WriteLine("---------------------------------");
    Console.WriteLine($"Stacktrace: {ex.StackTrace}");
    System.Console.WriteLine("---------------------------------");
    Console.WriteLine($"Stacktrace: {ex.ToString()}");
}
finally
{
    Console.WriteLine("Operación finalizada.");
}