using Aplicacion.Entidades;
using Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();

services.AddSingleton<NotificadorDiscordService>()
        .AddSingleton<NotificadorEmailService>();

var serviceProvider = services.BuildServiceProvider();

INotificadorService discordService = serviceProvider.GetService<NotificadorDiscordService>();
INotificadorService emailService = serviceProvider.GetService<NotificadorEmailService>();

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