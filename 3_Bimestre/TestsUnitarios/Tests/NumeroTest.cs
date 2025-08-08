using Aplicacion;

namespace Tests;

public class NumeroTest
{
    // [Fact]
    // public void CuandoSeSumeDosNumerosEnterosPositivos_DebeRetornarLaSuma()
    // {
    //     //Act
    //     Numero numero = new Numero();

    //     //Arrange
    //     int resultado = numero.Sumar(2, 7);

    //     //Assert
    //     Assert.Equal(9, resultado);
    // }

    // [Fact]
    // public void CuandoSeSumeDosNumerosEnterosNegativos_DebeRetornarLaSuma()
    // {
    //     //Act
    //     Numero numero = new Numero();

    //     //Arrange
    //     int resultado = numero.Sumar(-3, -2);

    //     //Assert
    //     Assert.Equal(-5, resultado);
    // }

    [Theory]
    [InlineData(2, 7, 9)]
    [InlineData(-2, -4, -6)]
    [InlineData(0, 3, 3)]
    [InlineData(4, 0, 4)]
    [InlineData(-2, 4, 2)]
    [InlineData(8, -5, 3)]
    public void CuandoSeSumeDosNumerosEnteros_DebeRetornarLaSuma(int a, int b, int resultadoEsperado)
    {
        //Act
        Numero numero = new Numero();

        //Arrange
        int resultado = numero.Sumar(a, b);

        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(-20, -4, 5)]
    [InlineData(3, 2, 1.5)]
    public void CuandoSeDividaDosNumerosEnteros_DebeRetornarLaDivision(float a, float b, float resultadoEsperado)
    {
        //Act
        Numero numero = new Numero();

        //Arrange
        float resultado = numero.Dividir(a, b);

        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(3, 0, 1.5)]
    public void CuandoSeDividaDosNumerosEnterosYDivisorEsCero_DebeRetornarLaExcepcion(float a, float b, float resultadoEsperado)
    {
        //Act
        Numero numero = new Numero();

        // //Arrange
        // float resultado = numero.Dividir(a, b);

        // //Assert
        // Assert.Equal(resultadoEsperado, resultado);

        Assert.Throws<DivideByZeroException>(() => numero.Dividir(a, b));
    }
}
