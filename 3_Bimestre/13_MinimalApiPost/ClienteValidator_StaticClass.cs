namespace MinimalApiPost;

public static class ClienteValidator_StaticClass
{
    public static string? ValidateId(int id)
    {
        if (id <= 0)
            return "El Id debe ser mayor que cero.";
        return null;
    }

    public static string? ValidateNombre(string? nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            return "El nombre es obligatorio.";
        if (nombre.Length < 2)
            return "El nombre debe tener al menos 2 caracteres.";
        return null;
    }

    public static string? ValidateEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return "El email es obligatorio.";
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address != email)
                return "El email no es válido.";
        }
        catch
        {
            return "El email no es válido.";
        }
        return null;
    }
}
