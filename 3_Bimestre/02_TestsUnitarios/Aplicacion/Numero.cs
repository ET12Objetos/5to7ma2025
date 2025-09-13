namespace Aplicacion;

public class Numero
{
    public int Sumar(int a, int b) => a + b;
    public int Dividir(int a, int b) => a / b;
    public float Dividir(float a, float b)
    {
        if (b != 0)
            return a / b;

        throw new DivideByZeroException("No se puede dividir por cero");
    }

}
