using EjemploReal;

IPublicacion publicacion1 = new PublicacionInstagram
{
    Descripcion = "instagram",
    Likes = 100
};

Console.WriteLine(publicacion1.ToString());

publicacion1.Publicar("vale por un mensaje 1");

Publicacion publicacion2 = new PublicacionTelegram
{
    Descripcion = "telegram",
    Likes = 300
};

Console.WriteLine(publicacion2.ToString());
publicacion2.Publicar("vale por un mensaje 2");