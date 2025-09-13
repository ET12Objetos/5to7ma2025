using Aplicacion.Servicios;

namespace Aplicacion.Entidades;

public class Profesor
{
    public required string Nombre { get; set; }

    public Curso Curso { get; set; }

    public readonly INotificadorService notificadorService;

    public Profesor(INotificadorService notificadorService)
    {
        this.notificadorService = notificadorService;
    }

    public void AsignarCurso(Curso curso)
    {
        Curso = curso;
    }

    //Sin inyeccion de dependencia
    // public void Notificar(INotificadorService notificador)
    // {
    //     notificador.Notificar(Curso.Alumnos);
    // }

    public void Notificar()
    {
        notificadorService.Notificar(Curso.Alumnos);
    }
}
