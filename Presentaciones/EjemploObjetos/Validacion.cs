namespace EjemploObjetos;

public static class Validacion
{
    public static void Cadena(string cadena, string mensaje)
    {
        if (string.IsNullOrEmpty(cadena))
        {
            throw new ArgumentException(mensaje);
        }
    }

    public static void Numero(int numero, string mensaje)
    {
        if (numero <= 0)
        {
            throw new ArgumentException(mensaje);
        }
    }
}