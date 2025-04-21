using EjemploRedSocial;

Usuario usuario = new Usuario("jonathan_dev", "jonathan@example.com");

usuario.CrearPublicacion("¡Hola mundo!");
usuario.CrearPublicacion("Primer post con C# y agregación");

// Simular likes
foreach (Publicacion publicacion in usuario.Publicaciones)
{
    publicacion.DarLike();
}

usuario.ListarPublicaciones();

var topPost = usuario.ObtenerPublicacionMasPopular();
Console.WriteLine($"Publicación más popular: {topPost}");