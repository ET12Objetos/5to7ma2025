using Aplicacion.Entidades;

namespace Aplicacion.Servicios;

public class NotificadorEmailService : INotificadorService
{
    public void Notificar(List<Alumno> alumnos)
    {
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine($"Enviar email {alumno.Email}");
        }
    }
}