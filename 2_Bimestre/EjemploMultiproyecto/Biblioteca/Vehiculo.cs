namespace Biblioteca;

public abstract class Vehiculo
{
    public string Motor { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;

    public abstract void Maniobrar();

    protected virtual void AbrirPuerta()
    {

    }
}