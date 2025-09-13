using Aplicacion.Entidades;

namespace Aplicacion.Servicios;

public class NotificadorEmail : INotificador
{
    public void Notificar(List<Alumno> alumnos)
    {
        //a quien le envio en email ??
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine($"Enviar email {alumno.Email}");
        }
    }
}