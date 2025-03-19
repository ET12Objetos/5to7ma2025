namespace EjemploTarjetaCredito; //se declara el espacio de nombres de la clase TarjetaCredito

public class TarjetaCredito
{
    public short CVV; //representa el codigo de verificacion de la tarjeta, tipo de dato short
    public string nombrePersona; //representa el nombre de la persona a la que pertenece la tarjeta, tipo de dato string
    public DateOnly fechaVencimiento; //representa la fecha de vencimiento de la tarjeta, tipo de dato DateOnly
    public DateOnly fechaEmision; //representa la fecha de emision de la tarjeta, tipo de dato DateOnly
    public string banco; //representa el banco emisor de la tarjeta, tipo de dato string
    public string empresaEmisora; //representa la empresa emisora de la tarjeta, tipo de dato string
    public string PAN; //representa el numero de cuenta de la tarjeta, tipo de dato string

    //TarjetaCredito es el metodo constructor de la clase TarjetaCredito
    //se ejecuta cuando se crea una instancia un objeto de la clase TarjetaCredito y encarga de inicializar los atributos 
    //de la clase TarjetaCredito
    //es el metodo que se encarga de asignar valores a los atributos de la clase TarjetaCredito
    //es el metodo que se encarga de asignar valores a los atributos de la clase TarjetaCredito, a traves de parametros, 
    //y de manera aleatoria
    //el nombre del metodo constructor es igual al nombre de la clase
    public TarjetaCredito(string nombrePersona, string banco, string empresaEmisora)
    {
        CVV = (short)new Random().Next(0, 999);
        this.nombrePersona = nombrePersona;
        fechaEmision = DateOnly.FromDateTime(DateTime.Now);
        fechaVencimiento = new DateOnly(fechaEmision.Year + 5, fechaEmision.Month, 1);
        this.banco = banco;
        this.empresaEmisora = empresaEmisora;
        PAN = "1234 5678 9012 3456";
    }
}