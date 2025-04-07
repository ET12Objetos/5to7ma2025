namespace Automovil_Composicion;

public class Automovil
{
    public string Patente = "";
    public string Modelo = string.Empty;
    public Motor motor;

    public Automovil(string Patente, string Modelo, Motor motor)
    {
        Validaciones.Cadena(Patente, "la patente es incorrecta");
        this.Patente = Patente;

        Validaciones.Cadena(Modelo, "el modelo es incorrecto");
        this.Modelo = Modelo;

        this.motor = motor;
    }

    public void EncenderMotor()
    {
        motor.Encender();
    }

    public void ApagarMotor()
    {
        motor.Apagar();
    }
}
