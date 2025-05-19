using EmailValidation;

namespace ValidacionesyCosasRandom;

public class ValidarEmail
{
    public bool ValidarConEmailValidation(string email)
    {
        bool isValid = EmailValidator.Validate(email);

        Console.WriteLine($"Is the email '{email}' valid? {isValid}");

        return isValid;
    }

    public bool ValidarConExpresionRegular(string email)
    {
        // Expresión regular para validar el formato del correo electrónico
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        bool isValid = System.Text.RegularExpressions.Regex.IsMatch(email, pattern);

        Console.WriteLine($"Is the email '{email}' valid? {isValid}");

        return isValid;
    }
}