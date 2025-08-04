namespace EjemploReal;

public class Publicacion : IPublicacion
{
    public string? Descripcion { get; set; }
    public int Likes { get; set; }

    public void Publicar(string Descripcion)
    {
        Console.WriteLine($"Publicando..: {Descripcion}");
    }

    public override string ToString()
    {
        return $"Descripcion: {Descripcion}, Likes: {Likes}";
    }
}