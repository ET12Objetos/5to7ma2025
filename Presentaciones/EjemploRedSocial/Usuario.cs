namespace EjemploRedSocial;

public partial class Usuario
{
    public string NombreDeUsuario;
    public string Email;

    // Agregación: la lista de publicaciones pertenece al usuario,
    // pero las publicaciones pueden existir fuera del objeto usuario.
    public List<Publicacion> Publicaciones;

    public Usuario(string nombreDeUsuario, string email)
    {
        NombreDeUsuario = nombreDeUsuario;
        Email = email;
        Publicaciones = new List<Publicacion>();
    }   
}