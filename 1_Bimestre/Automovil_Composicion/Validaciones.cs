namespace Automovil_Composicion;
public static class Validaciones
{
    public static void Cadena(string nombreAtributo, string mensajeError)
    {
        //logica escrita desde el punto de vista de la programacion orientada a objetos (haciendo uso del metodo del tipo de dato string)
        if (string.IsNullOrWhiteSpace(nombreAtributo))
            throw new ArgumentException(mensajeError);
    }

    public static void Numero(int numero, string mensajeError)
    {
        //logica escrita desde el punto de vista de la programacion orientada a objetos (haciendo uso del metodo del tipo de dato int)
        if (numero <= 0)
            throw new ArgumentException(mensajeError);
    }
}