Exception excepcion1 = new Exception("Error de prueba");

//throw excepcion1;

ArgumentException excepcion2 = new ArgumentException("Error de argument exception");

//throw excepcion2;

void ValidarCadenaNoVacia(string cadena)
{
    if (string.IsNullOrWhiteSpace(cadena))
    {
        throw new ArgumentException("La cadena no puede estar vacía o contener solo espacios en blanco.");
    }
}

ValidarCadenaNoVacia("");
