using PolimorfismoSubtipo;

Publicacion publicacion = new Publicacion
{
    Descripcion = "vale por una drescripcion",
    Likes = 1000
};

Console.WriteLine(publicacion.ToString());


PublicacionInstagram publicacionInstagram = new PublicacionInstagram
{
    Descripcion = "vale por una drescripcion",
    Likes = 1000,
    Compartidos = 30
};

Console.WriteLine(publicacionInstagram.ToString());
