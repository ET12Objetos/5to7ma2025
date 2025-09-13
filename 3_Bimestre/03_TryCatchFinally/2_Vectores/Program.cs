// Ejemplo 2 - Vectores

try
{
    int[] numeros = { 10, 20, 30, 40, 50 };
    Console.WriteLine("Vector creado correctamente.");

    // Intentar acceder a un índice que puede estar fuera del rango
    Console.Write("Ingrese el índice a consultar (0-4): ");
    string input = Console.ReadLine();
    int indice = int.Parse(input);

    int valor = numeros[indice];
    Console.WriteLine($"El valor en el índice {indice} es: {valor}");

    // Operación adicional que puede fallar
    int division = numeros[0] / numeros[indice];
    Console.WriteLine($"División: {numeros[0]} / {valor} = {division}");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Error: Índice fuera del rango del vector.");
    Console.WriteLine($"Detalle: {ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine("Error: Debe ingresar un número entero válido.");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Error: División por cero detectada en el vector.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}
finally
{
    Console.WriteLine("Operación con vector finalizada.");
    Console.WriteLine("Memoria del vector liberada automáticamente por GC.");
}