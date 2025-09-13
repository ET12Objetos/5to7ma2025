namespace Tests;

using Aplicacion;
using Xunit;
using System.Collections.Generic;

public class CursoTest
{
    private List<Alumno> _alumnos;
    private Curso _curso;
    
    public CursoTest()
    {
        // Inicializamos la lista y el curso en el constructor
        _alumnos = new List<Alumno>();
        _curso = new Curso("Matematica");
    }
    
    [Fact]
    public void DadoUnCurso_CuandoAgregoAlumnos_EntoncesSeAgreganCorrectamente()
    {
        // Usamos el curso inicializado en el constructor
        var alumno1 = new Alumno("Juan", 18);
        var alumno2 = new Alumno("Ana", 19);

        _curso.AgregarAlumno(alumno1);
        _curso.AgregarAlumno(alumno2);

        Assert.Equal(2, _curso.Alumnos.Count);
        Assert.Contains(alumno1, _curso.Alumnos);
        Assert.Contains(alumno2, _curso.Alumnos);
    }

    [Fact]
    public void DadoUnCursoNuevo_CuandoSeCrea_EntoncesLaListaDeAlumnosEstaVacia()
    {
        // Creamos un nuevo curso para esta prueba específica
        var cursoNuevo = new Curso("Historia");
        Assert.Empty(cursoNuevo.Alumnos);
        
        // También podemos verificar que nuestro curso de la clase inicializa correctamente
        // su lista si no hemos agregado alumnos en esta prueba
        _curso = new Curso("Otro curso");
        Assert.Empty(_curso.Alumnos);
    }
}
