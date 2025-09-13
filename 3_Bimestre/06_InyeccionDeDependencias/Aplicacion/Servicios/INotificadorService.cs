using Aplicacion.Entidades;

namespace Aplicacion.Servicios;

public interface INotificadorService
{
    void Notificar(List<Alumno> alumnos);
}