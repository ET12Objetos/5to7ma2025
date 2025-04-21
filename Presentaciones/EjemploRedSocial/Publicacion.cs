namespace EjemploRedSocial;

public class Publicacion
{
    public string Contenido;
    public DateTime FechaPublicacion;
    public int CantidadDeLikes;

    public Publicacion(string contenido)
    {
        Contenido = contenido;
        FechaPublicacion = DateTime.Now;
        CantidadDeLikes = 0;
    }

    public void DarLike()
    {
        CantidadDeLikes++;
    }
}