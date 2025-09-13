namespace PolimorfismoSubtipo;

public class Publicacion
{
    public string? Descripcion { get; set; }
    public int Likes { get; set; }

    public override string ToString()
    {
        return "HOla mundo!";
    }
}