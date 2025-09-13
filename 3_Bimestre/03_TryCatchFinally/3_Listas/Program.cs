//Ejemplo 3 - Listas

List<string> nombres = null;

try
{
    nombres = new List<string>();
    Console.WriteLine("Lista de nombres creada correctamente.");

    // Agregar elementos a la lista
    nombres.Add("Juan");
    nombres.Add("María");
    nombres.Add("Pedro");
    nombres.Add("Ana");

    Console.WriteLine($"Se agregaron {nombres.Count} nombres a la lista.");

    // Intentar acceder a un elemento por índice
    Console.Write("Ingrese el índice del nombre a consultar (0-3): ");
    string input = Console.ReadLine();
    int indice = int.Parse(input);

    string nombre = nombres[indice];
    Console.WriteLine($"El nombre en el índice {indice} es: {nombre}");

    // Buscar un nombre específico
    Console.Write("Ingrese un nombre a buscar: ");
    string nombreBuscar = Console.ReadLine();

    if (string.IsNullOrEmpty(nombreBuscar))
    {
        throw new ArgumentException("El nombre no puede estar vacío.");
    }

    int posicion = nombres.IndexOf(nombreBuscar);
    if (posicion >= 0)
    {
        Console.WriteLine($"'{nombreBuscar}' encontrado en la posición {posicion}");

        // Intentar remover el elemento
        bool removido = nombres.Remove(nombreBuscar);
        Console.WriteLine($"Elemento removido: {removido}");
        Console.WriteLine($"Elementos restantes en la lista: {nombres.Count}");
    }
    else
    {
        Console.WriteLine($"'{nombreBuscar}' no fue encontrado en la lista.");
    }

    // Mostrar todos los elementos restantes
    Console.WriteLine("Elementos restantes en la lista:");
    foreach (string n in nombres)
    {
        Console.WriteLine($"- {n}");
    }
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Error: Índice fuera del rango de la lista.");
    Console.WriteLine($"Detalle: {ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine("Error: Debe ingresar un número entero válido.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de argumento: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error de operación inválida: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado trabajando con listas: {ex.Message}");
}
finally
{
    if (nombres != null)
    {
        Console.WriteLine($"Operación con lista finalizada. Elementos finales: {nombres.Count}");
        nombres.Clear(); // Limpiar la lista
        Console.WriteLine("Lista limpiada y memoria liberada.");
    }
    else
    {
        Console.WriteLine("La lista no pudo ser inicializada.");
    }
}