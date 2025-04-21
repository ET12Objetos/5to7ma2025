namespace EjemploObjetos;

public class Lata
{
    public string Color { get; set; }

    public int Contenido { get; set; }

    public Lata(string color, int contenido)
    {
        Validacion.Cadena(color, "error");
        Color = color;

        Validacion.Numero(contenido, "error");
        Contenido = contenido;
    }
}

// public class Lata
// {

//     private string _color;
//     public string Color
//     {
//         get { return _color; }
//         set
//         {
//             Validacion.Cadena(value, "error");
//             _color = value;
//         }
//     }

//     private int _contenido;
//     public int Contenido
//     {
//         get { return _contenido; }
//         set
//         {
//             Validacion.Numero(value, "error");
//             _contenido = value;
//         }
//     }

//     public Lata(string color, int contenido)
//     {
//         Validacion.Cadena(color, "error");
//         Color = color;

//         Validacion.Numero(contenido, "error");
//         Contenido = contenido;
//     }
// }

// public class Lata
// {
//     public string Color { get; private set; }

//     public int Contenido { get; private set; }

//     public Lata(string color, int contenido)
//     {
//         Validacion.Cadena(color, "error");
//         Color = color;

//         Validacion.Numero(contenido, "error");
//         Contenido = contenido;
//     }

//     public void SetColor(string color)
//     {
//         Validacion.Cadena(color, "error");
//         Color = color;
//     }

//     public void SetContenido(int contenido)
//     {
//         Validacion.Numero(contenido, "error");
//         Contenido = contenido;
//     }
// }