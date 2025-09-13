//clasico
using System.Text;

Console.Write("Ingrese un nombre: ");
string nombre = Console.ReadLine();
Console.Write("Ingrese un apellido: ");
string apellido = Console.ReadLine();

string nombreCompleto = $"{apellido.ToUpper()}, {nombre}";

Console.WriteLine(nombreCompleto);

StringBuilder stringBuilder = new StringBuilder();

Console.Write("Ingrese un nombre: ");
stringBuilder.Append(Console.ReadLine());
Console.Write("Ingrese un apellido: ");
stringBuilder.Append(Console.ReadLine());

Console.WriteLine(stringBuilder.ToString());
