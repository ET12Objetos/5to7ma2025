using Aplicacion.Entidades;

namespace Aplicacion.Servicios;

public interface INotificador
{
    void Notificar(List<Alumno> alumnos);
}