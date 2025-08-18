using Aplicacion.Servicios;

namespace Aplicacion.Entidades;

public class Profesor
{
    public required string Nombre { get; set; }

    public Curso Curso { get; set; }

    public void AsignarCurso(Curso curso)
    {
        Curso = curso;
    }

    // private void EnviarEmail()
    // {
    //     //a quien le envio en email ??
    //     foreach (Alumno alumno in Curso.Alumnos)
    //     {
    //         Console.WriteLine($"Enviar email {alumno.Email}");
    //     }
    // }

    public void Notificar(INotificador notificador)
    {
        notificador.Notificar(Curso.Alumnos);
    }

    private void NotificarDiscord()
    {
        foreach (Alumno alumno in Curso.Alumnos)
        {
            Console.WriteLine($"Enviar email {alumno.UsuarioDiscord}");
        }
    }
}
