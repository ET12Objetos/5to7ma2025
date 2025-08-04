namespace EjemploReal;

public class PublicacionInstagram : Publicacion
{
    public int Compartidos { get; set; }

    public override string ToString()
    {
        return $"Cantidad Compartidos {Compartidos}";
    }
}