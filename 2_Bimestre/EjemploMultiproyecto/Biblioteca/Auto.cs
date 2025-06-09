namespace Biblioteca;

public class Auto : Vehiculo
{
    public override void Maniobrar()
    {
        System.Console.WriteLine("Anda a saber como funciona");
    }

    protected override void AbrirPuerta()
    {
        base.AbrirPuerta();
    }
}