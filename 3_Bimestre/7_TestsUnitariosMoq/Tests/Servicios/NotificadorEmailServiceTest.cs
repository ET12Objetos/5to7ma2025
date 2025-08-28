using Aplicacion.Entidades;
using Aplicacion.Servicios;
using Moq;

namespace Tests.Servicios;

public class NotificadorEmailServiceTest
{
    //Sin Moq
    [Fact]
    public void NotificadorEmailService_ShouldPrintEmailForEachAlumno()
    {
        // Arrange
        var alumnos = new List<Alumno>
            {
                new Alumno { Nombre = "Juan", Email = "juan@email.com", UsuarioDiscord = "juan#1234" },
                new Alumno { Nombre = "Ana", Email = "ana@email.com", UsuarioDiscord = "ana#5678" }
            };

        INotificadorService service = new NotificadorEmailService();

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        service.Notificar(alumnos);

        // Assert
        var output = sw.ToString();
        Assert.Contains("Enviar email juan@email.com", output);
        Assert.Contains("Enviar email ana@email.com", output);
    }

    //con Moq - Mock del servicio
    [Fact]
    public void Notificar_ShouldCallNotificarOnService()
    {
        // Arrange
        var alumnos = new List<Alumno>
            {
                new Alumno { Nombre = "Juan", Email = "juan@email.com", UsuarioDiscord = "juan#1234" },
                new Alumno { Nombre = "Ana", Email = "ana@email.com", UsuarioDiscord = "ana#5678" }
            };

        var mockService = new Mock<INotificadorService>();

        // Act
        mockService.Object.Notificar(alumnos);

        // Assert
        mockService.Verify(s => s.Notificar(alumnos), Times.Once);
    }

    //con Moq - Mock del servicio Y mock de la data
    [Fact]
    public void Notificar_ShouldVerifyInteractionWithMockedServiceAndData()
    {
        // Arrange - Creando data mockeada usando Mock.Of<T>
        var mockAlumno1 = Mock.Of<Alumno>(a =>
            a.Nombre == "Carlos Viteh" &&
            a.Email == "carlos.viteh@mock.com" &&
            a.UsuarioDiscord == "carlos_viteh#1111");

        var mockAlumno2 = Mock.Of<Alumno>(a =>
            a.Nombre == "Sofia Viteh" &&
            a.Email == "sofia.viteh@mock.com" &&
            a.UsuarioDiscord == "sofia_viteh#2222");

        var alumnosMockeados = new List<Alumno> { mockAlumno1, mockAlumno2 };

        // Mock del servicio
        var mockService = new Mock<INotificadorService>();

        // Configuramos el comportamiento esperado del mock
        mockService.Setup(s => s.Notificar(It.IsAny<List<Alumno>>()));

        // Act
        mockService.Object.Notificar(alumnosMockeados);

        // Assert - Verificamos que se llamó con los alumnos mockeados
        mockService.Verify(s => s.Notificar(alumnosMockeados), Times.Once);

        // Verificamos que los datos mockeados tienen los valores esperados
        Assert.Equal("Carlos Viteh", mockAlumno1.Nombre);
        Assert.Equal("carlos.viteh@mock.com", mockAlumno1.Email);
        Assert.Equal("Sofia Viteh", mockAlumno2.Nombre);
        Assert.Equal("sofia.viteh@mock.com", mockAlumno2.Email);
    }
}