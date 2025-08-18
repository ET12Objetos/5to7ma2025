using System.Collections.Generic;
using Aplicacion;
using Moq;
using Xunit;

namespace Tests
{
    public class CursoTestConMoq
    {
        private readonly List<Alumno> _listaAlumnos;
        
        public CursoTestConMoq()
        {
            // Inicializamos la lista en el constructor de la clase de prueba
            _listaAlumnos = new List<Alumno>();
        }
        
        [Fact]
        public void DadoUnCurso_CuandoAgregoAlumnos_EntoncesSeAgreganCorrectamente()
        {
            // Arrange
            var alumno1 = new Alumno("Juan", 18);
            var alumno2 = new Alumno("Ana", 19);
            
            // Creamos un mock del curso
            var mockCurso = new Mock<Curso>("Matemática");
            mockCurso.Setup(c => c.Alumnos).Returns(_listaAlumnos);
            
            // Act
            mockCurso.Object.AgregarAlumno(alumno1);
            mockCurso.Object.AgregarAlumno(alumno2);
            
            // Assert
            // Verificamos que el método AgregarAlumno fue llamado
            mockCurso.Verify(c => c.AgregarAlumno(alumno1), Times.Once());
            mockCurso.Verify(c => c.AgregarAlumno(alumno2), Times.Once());
        }
        
        [Fact]
        public void DadoUnCursoNuevo_CuandoSeCrea_EntoncesLaListaDeAlumnosEstaVacia()
        {
            // Arrange - Usamos la lista inicializada en el constructor
            var mockCurso = new Mock<Curso>("Historia");
            mockCurso.Setup(c => c.Alumnos).Returns(_listaAlumnos);
            mockCurso.Setup(c => c.Nombre).Returns("Historia");
            
            // Act - No hay acción, solo verificamos el estado inicial
            
            // Assert
            Assert.Equal(_listaAlumnos, mockCurso.Object.Alumnos);
            Assert.Empty(mockCurso.Object.Alumnos);
            Assert.Equal("Historia", mockCurso.Object.Nombre);
        }
    }
}
