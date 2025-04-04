//texto --------------------------------------------------------------------------------

//ingrear una cadena de caracteres
Console.WriteLine("Ingrese una cadena de texto:");
string input1 = Console.ReadLine();
Console.WriteLine(input1);

//ingresar un caracter
Console.WriteLine("Ingrese un caracter:");
char input2 = char.Parse(Console.ReadLine());
Console.WriteLine(input2);

//numeros --------------------------------------------------------------------------------

//ingresar un numero entero
Console.WriteLine("Ingrese un numero entero:");
int input3 = int.Parse(Console.ReadLine());
Console.WriteLine(input3);

//ingresar un numero de tipo long (entero muy grande)
Console.WriteLine("Ingrese un numero de tipo long:");
long input4 = long.Parse(Console.ReadLine());
Console.WriteLine(input4);

//ingresar un numero decimal (para manejo de dinero)
Console.WriteLine("Ingrese un numero decimal:");
decimal input5 = decimal.Parse(Console.ReadLine());
Console.WriteLine(input5);

//ingresar un numero con punto flotante
Console.WriteLine("Ingrese un numero con punto flotante:");
float input6 = float.Parse(Console.ReadLine());
Console.WriteLine(input6);

//ingresar un numero de tipo double (punto flotante de doble precision, muy grande)
Console.WriteLine("Ingrese un numero de tipo double:");
double input7 = double.Parse(Console.ReadLine());
Console.WriteLine(input7);

//booleano --------------------------------------------------------------------------------

//ingresar valor booleano true o false siempre en minusculas y en ingles
Console.WriteLine("Ingrese un valor booleano (true/false):");
bool input8 = bool.Parse(Console.ReadLine());
Console.WriteLine(input8);

//fechas y horas --------------------------------------------------------------------------------

//ingresar una fecha con formato dd/MM/yyyy
Console.WriteLine("Ingrese una fecha (dd/MM/yyyy):");
DateTime input9 = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
Console.WriteLine(input9);

//ingresar una fecha con formato yyyy-MM-dd
Console.WriteLine("Ingrese una fecha (yyyy-MM-dd):");
DateTime input10 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
Console.WriteLine(input10);

//ingresar una fecha y hora con formato dd/MM/yyyy HH:mm:ss
Console.WriteLine("Ingrese una fecha y hora (dd/MM/yyyy HH:mm:ss):");
DateTime input11 = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null);
Console.WriteLine(input11);

//ingresar una fecha y hora con formato yyyy-MM-dd HH:mm:ss
Console.WriteLine("Ingrese una fecha y hora (yyyy-MM-dd HH:mm:ss):");
DateTime input12 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null);
Console.WriteLine(input12);