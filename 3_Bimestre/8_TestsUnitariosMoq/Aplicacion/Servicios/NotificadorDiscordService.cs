using Aplicacion.Entidades;

namespace Aplicacion.Servicios;

public class NotificadorDiscordService : INotificadorService
{
    public void Notificar(List<Alumno> alumnos)
    {
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine($"Enviar mensaje a {alumno.UsuarioDiscord}");
        }
    }
}