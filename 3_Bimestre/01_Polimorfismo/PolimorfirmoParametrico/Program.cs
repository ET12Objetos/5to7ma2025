static int Sumar(int a, int b, int c = 0)
{
    return a + b + c;
}

int resultado = Sumar(2, 7);
Console.WriteLine(resultado);

resultado = Sumar(2, 7, 10);
Console.WriteLine(resultado);