using EjemploTarjetaCredito; //se debe refenciar el proyecto EjemploTarjetaCredito

//=================================================
//usuario ingrese su nombre, banco y la empresa emisora por teclado/pantalla
Console.Write("Ingrese su nombre: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese su banco: ");
string banco = Console.ReadLine();

Console.Write("Ingrese la empresa emisora: ");
string empresaEmisora = Console.ReadLine();
//=================================================

//formas de instanciar (crear) un objeto de la clase TarjetaCredito

//-----------------1ra forma (en dos lineas, declaracion y luego asignacion)--------------------------------------------------
// TarjetaCredito tarjetaCredito;
// tarjetaCredito = new TarjetaCredito();

//-----------------2da forma (en una linea se declara y se asigna) RECOMENDADA-------------------------------------------------
TarjetaCredito tarjetaCredito = new TarjetaCredito(nombre, banco, empresaEmisora);

//-----------------3ra forma (en una linea se declara y se asigna, pero se usa el tipo de dato "var")---------------------------
//var tarjetaCredito = new TarjetaCredito();

//-----------------4ta forma (en una linea se declara y se asigna, no se especifica el nombre de la clase despues del new)-------
//TarjetaCredito tarjetaCredito = new("Juan Perez", "Banco de Chile", "Visa");
//=================================================

//asignar valores a los atributos de la clase TarjetaCredito, se acceden mediante un punto
// tarjetaCredito.CVV = 123;
// tarjetaCredito.nombrePersona = "Juan Perez";
// tarjetaCredito.fechaVencimiento = new DateOnly(2022, 12, 31);

//imprimir los valores de los atributos de la clase TarjetaCredito
Console.WriteLine("CVV: " + tarjetaCredito.CVV);
Console.WriteLine("Nombre: " + tarjetaCredito.nombrePersona);
Console.WriteLine("Fecha de vencimiento: " + tarjetaCredito.fechaVencimiento);
Console.WriteLine("Fecha de emisión: " + tarjetaCredito.fechaEmision);
Console.WriteLine("Banco: " + tarjetaCredito.banco);
Console.WriteLine("Empresa emisora: " + tarjetaCredito.empresaEmisora);
Console.WriteLine("PAN: " + tarjetaCredito.PAN);