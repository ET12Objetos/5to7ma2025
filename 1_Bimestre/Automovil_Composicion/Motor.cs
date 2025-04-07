namespace Automovil_Composicion;

public class Motor
{
    public string tipo;

    public int velocidadMaxima;

    public bool estado;

    public Motor(string modelo, string tipo, int potencia, int velocidadMaxima)
    {
        Validaciones.Cadena(tipo, "el tipo es incorrecto");
        this.tipo = tipo;
        Validaciones.Numero(velocidadMaxima, "la velocidad máxima es incorrecta");
        this.velocidadMaxima = velocidadMaxima;
    }

    public void Encender()
    {
        if (estado)
            throw new Exception("El motor ya está encendido.");
        else
            estado = true;
    }

    public void Apagar()
    {
        if (!estado)
            throw new Exception("El motor ya está apagado.");
        else
            estado = false;
    }
}