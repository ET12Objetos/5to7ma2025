using Aplicacion.Entidades;
using Aplicacion.Servicios;

Profesor profesor = new Profesor()
{
    Nombre = "Juan"
};

Alumno alumno = new Alumno
{
    Nombre = "Juan",
    Email = "juan@mail.com",
    UsuarioDiscord = "user1"
};

Curso curso = new Curso(profesor);
curso.AgregarAlumno(alumno);


//INVERSION DE CONTROL

//viejo
// profesor.EnviarEmail();
// profesor.NotificarDiscord();

//moderno
INotificador email = new NotificadorEmail();
INotificador discord = new NotificadorDiscord();

profesor.Notificar(discord);

