namespace Comportamiento;

public class Automovil
{
    //atributos
    public string Patente;
    public string Modelo;
    public bool EstadoMotor;

    //método constructor
    public Automovil(string Patente, string Modelo)
    {
        ValidarPatente(Patente);
        ValidarModelo(Modelo);
        this.EstadoMotor = false;
    }

    //comportamiento de validacion de datos
    public void ValidarModelo(string modelo)
    {
        if (modelo == "")
            Console.WriteLine("el modelo es incorrecto");
        else
            this.Modelo = modelo;
    }

    public void ValidarPatente(string patente)
    {
        if (patente == "")
            Console.WriteLine("la patente es incorrecta");
        else
            this.Patente = patente;
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
