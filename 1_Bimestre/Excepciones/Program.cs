Exception exception = new Exception("Mensaje de error");

//throw exception; // Lanza la excepción
// El programa se detiene aquí y no se ejecuta el siguiente código

Console.WriteLine("Ingrese un numero:");
int numero = int.Parse(Console.ReadLine());

if (numero <= 0)
    throw new Exception("El numero es incorrecto");