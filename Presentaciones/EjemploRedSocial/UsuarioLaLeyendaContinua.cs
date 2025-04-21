namespace EjemploRedSocial;

public partial class Usuario
{
    public void CrearPublicacion(string contenido)
    {
        var nueva = new Publicacion(contenido);
        Publicaciones.Add(nueva);
    }

    public void ListarPublicaciones()
    {
        if (Publicaciones.Count == 0)
        {
            Console.WriteLine("No hay publicaciones.");
            return;
        }

        Console.WriteLine($"Publicaciones de {NombreDeUsuario}:");
        foreach (var pub in Publicaciones)
        {
            Console.WriteLine(pub);
        }
    }

    public Publicacion ObtenerPublicacionMasPopular()
    {
        return Publicaciones.OrderByDescending(p => p.CantidadDeLikes).First();
    }
}