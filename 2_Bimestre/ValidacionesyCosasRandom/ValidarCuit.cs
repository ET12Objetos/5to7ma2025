namespace ValidacionesyCosasRandom;

public class ValidarCuit
{
    public bool Validar(string cuit)
    {
        // Eliminar caracteres no numéricos
        cuit = new string(cuit.Where(char.IsDigit).ToArray());

        // Verificar longitud
        if (cuit.Length != 11)
        {
            Console.WriteLine($"El CUIT '{cuit}' no es válido. Debe tener 11 dígitos.");
            return false;
        }

        // Calcular el dígito verificador
        int suma = 0;
        int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 10; i++)
        {
            suma += (cuit[i] - '0') * multiplicadores[i];
        }
        int digitoVerificador = (11 - (suma % 11)) % 11;

        // Comparar con el dígito verificador del CUIT
        if (digitoVerificador == 10) digitoVerificador = 0;
        if (cuit[10] - '0' != digitoVerificador)
        {
            Console.WriteLine($"El CUIT '{cuit}' no es válido. El dígito verificador no coincide.");
            return false;
        }

        Console.WriteLine($"El CUIT '{cuit}' es válido.");
        return true;
    }
}