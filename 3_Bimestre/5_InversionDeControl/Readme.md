# Inversión de Control (IoC) - Proyecto Aplicación

## ¿Qué es la Inversión de Control?

La Inversión de Control (IoC) es un principio de diseño donde el control del flujo de ejecución y la gestión de dependencias se invierte respecto al diseño tradicional. En lugar de que una clase cree directamente sus dependencias, estas son proporcionadas desde el exterior.

## Ejemplo en la Biblioteca "Aplicacion"

En este proyecto, podemos observar claramente la aplicación de IoC en el sistema de notificaciones:

### Antes de IoC (Código comentado en Profesor.cs)
```csharp
// ACOPLAMIENTO FUERTE - SIN IoC
private void EnviarEmail()
{
    // La clase Profesor está acoplada directamente al método de notificación por email
    foreach (Alumno alumno in Curso.Alumnos)
    {
        Console.WriteLine($"Enviar email {alumno.Email}");
    }
}

private void NotificarDiscord()
{
    // Si queremos Discord, necesitamos otro método específico
    foreach (Alumno alumno in Curso.Alumnos)
    {
        Console.WriteLine($"Enviar email {alumno.UsuarioDiscord}");
    }
}
```

### Después de IoC (Implementación actual)

#### 1. Interfaz INotificador (Abstracción)
```csharp
public interface INotificador
{
    void Notificar(List<Alumno> alumnos);
}
```

#### 2. Implementaciones Concretas
```csharp
// Notificación por Email
public class NotificadorEmail : INotificador
{
    public void Notificar(List<Alumno> alumnos)
    {
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine($"Enviar email {alumno.Email}");
        }
    }
}

// Notificación por Discord
public class NotificadorDiscord : INotificador
{
    public void Notificar(List<Alumno> alumnos)
    {
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine($"Enviar email {alumno.UsuarioDiscord}");
        }
    }
}
```

#### 3. Clase Profesor usando IoC
```csharp
public void Notificar(INotificador notificador)
{
    // El Profesor NO decide cómo notificar
    // Recibe el comportamiento desde afuera (Inversión de Control)
    notificador.Notificar(Curso.Alumnos);
}
```

## Beneficios de IoC en este proyecto

### 1. **Desacoplamiento**
- La clase `Profesor` no depende de implementaciones concretas
- Solo conoce la interfaz `INotificador`

### 2. **Flexibilidad**
```csharp
// Uso desde el código cliente:
var profesor = new Profesor();

// Puedo elegir el tipo de notificación sin modificar Profesor
profesor.Notificar(new NotificadorEmail());    // Por email
profesor.Notificar(new NotificadorDiscord());  // Por Discord
```

### 3. **Extensibilidad**
Agregar nuevos tipos de notificación es simple:
```csharp
public class NotificadorSMS : INotificador
{
    public void Notificar(List<Alumno> alumnos)
    {
        // Implementación SMS
    }
}
```

### 4. **Testabilidad**
Es fácil crear mocks para testing:
```csharp
public class NotificadorMock : INotificador
{
    public void Notificar(List<Alumno> alumnos)
    {
        // Mock para pruebas unitarias
    }
}
```

## Conclusión

En la biblioteca "Aplicacion", IoC se implementa mediante:
- **Interfaz**: `INotificador` define el contrato
- **Implementaciones**: `NotificadorEmail` y `NotificadorDiscord` 
- **Inyección**: El método `Notificar()` de `Profesor` recibe la dependencia como parámetro

Esto permite que el **control** de qué tipo de notificación usar esté **invertido**: no lo decide la clase `Profesor`, sino el código que la utiliza.
