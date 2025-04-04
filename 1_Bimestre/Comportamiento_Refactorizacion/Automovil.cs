namespace Comportamiento_Refactorizacion;

public class Automovil
{
    //atributos
    public string Patente = "";
    public string Modelo = string.Empty;
    public bool EstadoMotor;

    //método constructor
    public Automovil(string Patente, string Modelo)
    {
        Validaciones.Cadena(Patente, "la patente es incorrecta");
        this.Patente = Patente;

        Validaciones.Cadena(Modelo, "el modelo es incorrecto");
        this.Modelo = Modelo;

        this.EstadoMotor = false;
    }

    //compotamiento de encendido y apagado del automovil
    public void Arrancar()
    {
        if (EstadoMotor == false)
            EstadoMotor = true;
        else
            Console.WriteLine("el automovil se encuentra encendido");
    }

    public void Apagar()
    {
        if (EstadoMotor == true)
            EstadoMotor = false;
        else
            Console.WriteLine("el automovil se encuentra apagado");
    }
}
