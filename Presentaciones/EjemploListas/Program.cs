using EjemploListas;

List<Producto> productos = new List<Producto>();

// Agregar productos con Add
productos.Add(new Producto("Arroz", 150.00m, true));
productos.Add(new Producto("Fideos", 120.50m, true));
productos.Add(new Producto("Aceite", 980.75m, false));
productos.Add(new Producto("Harina", 180.00m, true));

Console.WriteLine("Lista original:");
MostrarLista(productos);

// Eliminar producto por valor
var productoAEliminar = productos.Find(p => p.Nombre == "Fideos");

bool eliminado = productos.Remove(productoAEliminar);

Console.WriteLine($"Eliminando 'Fideos'... ¿Eliminado? {eliminado}");

// Eliminar producto por índice (por ejemplo, eliminar el primero)
if (productos.Count > 0)
{
    Console.WriteLine($"Eliminando producto en índice 0: {productos[0].Nombre}");
    productos.RemoveAt(0);
}

Console.WriteLine("Lista final:");
MostrarLista(productos);

static void MostrarLista(List<Producto> productos)
{
    if (productos.Count == 0)
    {
        Console.WriteLine("La lista está vacía.");
        return;
    }

    for (int i = 0; i < productos.Count; i++)
    {
        Console.WriteLine($"[{i}] {productos[i]}");
    }
}