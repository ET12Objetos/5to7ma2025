using Xunit;
using Moq;
using Aplicacion.Servicios;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Tests.Servicios
{
    public class UsuarioServicioTests
    {
        private readonly Mock<IUsuarioRepositorio> _mockUsuarioRepo;
        private readonly UsuarioServicio _usuarioServicio;

        public UsuarioServicioTests()
        {
            _mockUsuarioRepo = new Mock<IUsuarioRepositorio>();
            _usuarioServicio = new UsuarioServicio(_mockUsuarioRepo.Object);
        }

        [Fact]
        public void ObtenerUsuarioPorId_DeberiaRetornarUsuario_CuandoExiste()
        {
            // Arrange
            var usuarioId = 1;
            var usuarioEsperado = new Usuario
            {
                Id = usuarioId,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan@example.com",
                NombreUsuario = "jperez"
            };

            _mockUsuarioRepo.Setup(x => x.ObtenerPorId(usuarioId))
                          .Returns(usuarioEsperado);

            // Act
            var resultado = _usuarioServicio.ObtenerUsuarioPorId(usuarioId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(usuarioEsperado.Id, resultado.Id);
            Assert.Equal(usuarioEsperado.Nombre, resultado.Nombre);
            Assert.Equal(usuarioEsperado.Email, resultado.Email);
        }

        [Fact]
        public void CrearUsuario_DeberiaLanzarExcepcion_CuandoEmailYaExiste()
        {
            // Arrange
            var email = "test@example.com";
            _mockUsuarioRepo.Setup(x => x.ExisteEmail(email))
                          .Returns(true);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => _usuarioServicio.CrearUsuario("Juan", "Pérez", email, "jperez", "password")
            );
        }

        [Fact]
        public void CrearUsuario_DeberiaLanzarExcepcion_CuandoNombreUsuarioYaExiste()
        {
            // Arrange
            var nombreUsuario = "jperez";
            _mockUsuarioRepo.Setup(x => x.ExisteEmail(It.IsAny<string>()))
                          .Returns(false);
            _mockUsuarioRepo.Setup(x => x.ExisteNombreUsuario(nombreUsuario))
                          .Returns(true);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => _usuarioServicio.CrearUsuario("Juan", "Pérez", "test@example.com", nombreUsuario, "password")
            );
        }

        [Fact]
        public void CrearUsuario_DeberiaCrearUsuario_CuandoDatosValidos()
        {
            // Arrange
            var usuarioCreado = new Usuario
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "test@example.com",
                NombreUsuario = "jperez"
            };

            _mockUsuarioRepo.Setup(x => x.ExisteEmail(It.IsAny<string>()))
                          .Returns(false);
            _mockUsuarioRepo.Setup(x => x.ExisteNombreUsuario(It.IsAny<string>()))
                          .Returns(false);
            _mockUsuarioRepo.Setup(x => x.Crear(It.IsAny<Usuario>()))
                          .Returns(usuarioCreado);

            // Act
            var resultado = _usuarioServicio.CrearUsuario("Juan", "Pérez", "test@example.com", "jperez", "password");

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Juan", resultado.Nombre);
            Assert.Equal("test@example.com", resultado.Email);
            _mockUsuarioRepo.Verify(x => x.Crear(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public void ValidarCredenciales_DeberiaRetornarFalse_CuandoUsuarioNoExiste()
        {
            // Arrange
            _mockUsuarioRepo.Setup(x => x.ObtenerPorNombreUsuario(It.IsAny<string>()))
                          .Returns((Usuario?)null);

            // Act
            var resultado = _usuarioServicio.ValidarCredenciales("usuario_inexistente", "password");

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ActivarUsuario_DeberiaRetornarTrue_CuandoUsuarioExiste()
        {
            // Arrange
            var usuarioId = 1;
            _mockUsuarioRepo.Setup(x => x.ActivarUsuario(usuarioId))
                          .Returns(true);

            // Act
            var resultado = _usuarioServicio.ActivarUsuario(usuarioId);

            // Assert
            Assert.True(resultado);
            _mockUsuarioRepo.Verify(x => x.ActivarUsuario(usuarioId), Times.Once);
        }
    }
}
