namespace Comportamiento_Excepciones;
public static class Validaciones
{
    public static void Cadena(string atributo, string error)
    {
        if (atributo == "")
            Console.WriteLine(error);
    }
}