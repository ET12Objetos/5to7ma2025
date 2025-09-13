using PolimorfismoSobrecarga;

//constructor con 2 parámetros (obligatorio y opcional)
Alumno alumno1 = new Alumno("Juan", 20);

//constructor con 1 parámetro (unicamente obligatorio)
Alumno alumno2 = new Alumno("Martin");

Profesor profesor = new Profesor("Rodolfo", 12);

//polimorfismo de sobrecarga
Console.WriteLine(alumno1.ObtenerDescripcion());
Console.WriteLine(alumno1.ObtenerDescripcion("un nombre", 100));
Console.WriteLine(alumno1.ObtenerDescripcion(alumno2));

Console.WriteLine(profesor.ObtenerDescripcion());


