using Aplicacion.Entidades;
using Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;

//Con inyeccion de dependencia - paquete nuget
ServiceCollection services = new ServiceCollection();
services.AddSingleton<NotificadorDiscordService>()
        .AddSingleton<NotificadorEmailService>();
var serviceProvider = services.BuildServiceProvider();

INotificadorService discordService = serviceProvider.GetService<NotificadorDiscordService>();
INotificadorService emailService = serviceProvider.GetService<NotificadorEmailService>();

//Con inyeccion de dependencia - manual
// INotificadorService emailService = new NotificadorEmailService();
// INotificadorService discordService = new NotificadorDiscordService();

//Sin inyeccion de dependencia
// profesor.Notificar(discord);
// profesor.Notificar(email);

#region Instancia de objetos
Profesor profesor = new Profesor(discordService)
{
    Nombre = "JuanProfesor"
};

Profesor profesor2 = new Profesor(emailService)
{
    Nombre = "JuanProfesor2"
};

Alumno alumno = new Alumno
{
    Nombre = "JuanAlumno",
    Email = "juan@mail.com",
    UsuarioDiscord = "user1"
};

Curso curso = new Curso(profesor);
curso.AgregarAlumno(alumno);
#endregion