using Aplicacion.Entidades;
using Aplicacion.Servicios;
using Moq;

namespace Tests.Servicios;

public class NotificadorDiscordServiceTest
{
    private readonly Mock<INotificadorService> _mockService;
    private readonly List<Alumno> _alumnos;

    public NotificadorDiscordServiceTest()
    {
        // Configuración de mocks en el constructor - Inyección de dependencias
        _mockService = new Mock<INotificadorService>();

        // Data real configurada en el constructor (sin mocks ya que Alumno no tiene propiedades virtuales)
        _alumnos = new List<Alumno>
        {
            new Alumno
            {
                Nombre = "Pedro Constructor",
                Email = "pedro.constructor@email.com",
                UsuarioDiscord = "pedro_constructor#9999"
            },
            new Alumno
            {
                Nombre = "Maria Constructor",
                Email = "maria.constructor@email.com",
                UsuarioDiscord = "maria_constructor#8888"
            }
        };

        // Configurar comportamiento del mock service
        _mockService.Setup(s => s.Notificar(It.IsAny<List<Alumno>>()));
    }

    [Fact]
    public void Notificar_ShouldCallInjectedMockedService()
    {
        // Arrange - Usando servicio mockeado inyectado con data real inyectada

        // Act
        _mockService.Object.Notificar(_alumnos);

        // Assert
        _mockService.Verify(s => s.Notificar(_alumnos), Times.Once);

        // Verificar que los datos están correctos
        Assert.Equal(2, _alumnos.Count);
        Assert.Contains(_alumnos, a => a.UsuarioDiscord == "pedro_constructor#9999");
        Assert.Contains(_alumnos, a => a.UsuarioDiscord == "maria_constructor#8888");
    }

    [Fact]
    public void Notificar_ShouldHandleEmptyList_UsingInjectedService()
    {
        // Arrange - Usando servicio mockeado con lista vacía
        var emptyList = new List<Alumno>();

        // Act
        _mockService.Object.Notificar(emptyList);

        // Assert
        _mockService.Verify(s => s.Notificar(emptyList), Times.Once);
        _mockService.Verify(s => s.Notificar(It.Is<List<Alumno>>(list => list.Count == 0)), Times.Once);
    }
}