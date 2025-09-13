# ConstructorCadena - Demostración de Construcción de Cadenas

Esta aplicación de consola en C# demuestra dos enfoques diferentes para construir y manipular cadenas de texto en .NET.

## Qué hace el Código

El programa muestra dos métodos de manipulación de cadenas:

### Método 1: Concatenación Clásica de Cadenas
1. Solicita al usuario que ingrese un nombre
2. Solicita al usuario que ingrese un apellido
3. Crea una cadena de nombre completo formateada usando interpolación de cadenas: `"APELLIDO, Nombre"`
4. Muestra el resultado con el apellido en mayúsculas

### Método 2: Enfoque StringBuilder
1. Utiliza la clase `StringBuilder` para la construcción de cadenas
2. Solicita al usuario que ingrese un nombre
3. Solicita al usuario que ingrese un apellido
4. Añade ambas entradas al StringBuilder
5. Convierte el StringBuilder a cadena y lo muestra

## Estructura del Código

```csharp
// Enfoque de concatenación clásica
string nombreCompleto = $"{apellido.ToUpper()}, {nombre}";

// Enfoque StringBuilder  
StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append(Console.ReadLine());
stringBuilder.Append(Console.ReadLine());
```

## Conceptos Clave Demostrados

### Interpolación de Cadenas
- Usa la sintaxis `$"{variable}"` para incorporar variables en cadenas
- Más legible que la concatenación tradicional

### Métodos de Cadenas
- `ToUpper()`: Convierte texto a mayúsculas
- Demuestra manipulación básica de cadenas

### Clase StringBuilder
- **Propósito**: Construcción eficiente de cadenas para múltiples operaciones
- **Ventaja**: Mejor rendimiento al construir cadenas con muchas operaciones
- **Uso**: El método `Append()` añade contenido, `ToString()` convierte a cadena final

## Cuándo Usar Cada Método

### Concatenación Clásica de Cadenas
- **Mejor para**: Operaciones simples de cadenas, de una sola vez
- **Rendimiento**: Bueno para pequeño número de concatenaciones
- **Legibilidad**: Muy claro y directo

### StringBuilder
- **Mejor para**: Múltiples operaciones de cadenas o construcción de cadenas grandes
- **Rendimiento**: Más eficiente para modificaciones repetidas de cadenas
- **Memoria**: Reduce la sobrecarga de asignación de memoria

## Cómo Ejecutar

1. Asegúrate de tener instalado el SDK de .NET 9.0
2. Navega al directorio del proyecto
3. Ejecuta los siguientes comandos:

```bash
dotnet build
dotnet run
```

## Salida de Ejemplo

```
Ingrese un nombre: Juan
Ingrese un apellido: Pérez
PÉREZ, Juan

Ingrese un nombre: María
Ingrese un apellido: González
MaríaGonzález
```
