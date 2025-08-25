# Proyecto de Inyección de Dependencias

Este proyecto demuestra la implementación y uso de la Inyección de Dependencias (DI) en una aplicación .NET, utilizando el paquete `Microsoft.Extensions.DependencyInjection`. El proyecto simula un sistema educativo simple donde profesores pueden enviar notificaciones a los alumnos a través de diferentes medios (email o Discord).

## Estructura del Proyecto

El proyecto está organizado en dos proyectos principales:

- **Aplicacion**: Biblioteca de clases que contiene las entidades y servicios del dominio
- **Consola**: Aplicación de consola que utiliza la biblioteca y demuestra la inyección de dependencias

### Aplicacion

Este proyecto contiene:

#### Entidades

1. **Alumno.cs**: Representa a un estudiante con sus datos personales
   - Propiedades: Nombre, Email, UsuarioDiscord

2. **Profesor.cs**: Representa a un profesor que puede notificar a sus alumnos
   - Recibe un servicio de notificación a través de inyección de dependencias en su constructor
   - Implementa un método `Notificar()` que utiliza el servicio inyectado

3. **Curso.cs**: Representa un curso con alumnos y un profesor asignado
   - Mantiene una lista de alumnos
   - Permite agregar alumnos al curso

#### Servicios

1. **INotificadorService.cs**: Interfaz que define el contrato para los servicios de notificación
   - Define el método `Notificar(List<Alumno> alumnos)`

2. **NotificadorEmailService.cs**: Implementación del servicio que envía notificaciones por email
   - Implementa `INotificadorService`
   - Notifica a los alumnos utilizando sus direcciones de email

3. **NotificadorDiscordService.cs**: Implementación del servicio que envía notificaciones por Discord
   - Implementa `INotificadorService`
   - Notifica a los alumnos utilizando sus nombres de usuario de Discord

### Consola

Este proyecto contiene:

- **Program.cs**: Punto de entrada de la aplicación que configura el contenedor de DI y utiliza los servicios

## Inyección de Dependencias

El proyecto demuestra tres enfoques diferentes para manejar dependencias:

### 1. Sin Inyección de Dependencias

Código comentado que muestra cómo se trabajaría sin DI, pasando directamente las implementaciones a los métodos que las requieren:

```csharp
// Sin inyección de dependencia
// profesor.Notificar(discord);
// profesor.Notificar(email);
```

### 2. Inyección de Dependencias Manual

Código comentado que muestra cómo se implementaría la DI manualmente, creando instancias de los servicios e inyectándolos en el constructor:

```csharp
// Con inyeccion de dependencia - manual
// INotificadorService emailService = new NotificadorEmailService();
// INotificadorService discordService = new NotificadorDiscordService();
```

### 3. Inyección de Dependencias con Contenedor DI

El enfoque implementado actualmente, utilizando el contenedor de DI de Microsoft:

```csharp
// Con inyeccion de dependencia - paquete nuget
ServiceCollection services = new ServiceCollection();
services.AddSingleton<NotificadorDiscordService>()
        .AddSingleton<NotificadorEmailService>();
var serviceProvider = services.BuildServiceProvider();

INotificadorService discordService = serviceProvider.GetService<NotificadorDiscordService>();
INotificadorService emailService = serviceProvider.GetService<NotificadorEmailService>();
```

## Beneficios de la Inyección de Dependencias

1. **Desacoplamiento**: Las clases no dependen directamente de implementaciones concretas, sino de abstracciones.
2. **Testabilidad**: Facilita la creación de pruebas unitarias al permitir reemplazar implementaciones reales por mocks.
3. **Flexibilidad**: Permite cambiar implementaciones sin modificar el código que las utiliza.
4. **Mantenibilidad**: El código es más limpio y sigue el principio de inversión de dependencias.

## Ciclo de Vida de los Servicios

En este proyecto, los servicios están configurados como `Singleton`, lo que significa que se crea una única instancia que se reutiliza durante toda la vida de la aplicación. Otros ciclos de vida disponibles son:

- **Transient**: Una nueva instancia se crea cada vez que se solicita el servicio
- **Scoped**: Una instancia se crea por cada ámbito (útil en aplicaciones web donde el ámbito es la solicitud HTTP)

## Cómo Ejecutar el Proyecto

1. Asegúrate de tener .NET 9.0 instalado
2. Abre el proyecto en Visual Studio o VS Code
3. Restaura los paquetes NuGet (`dotnet restore`)
4. Compila el proyecto (`dotnet build`)
5. Ejecuta la aplicación (`dotnet run --project Consola`)

## Extensiones y Mejoras Posibles

- Implementar más servicios de notificación (por ejemplo, SMS, WhatsApp)
- Configurar servicios con opciones personalizables
- Agregar logging para registrar las notificaciones enviadas
- Implementar un sistema de eventos y manejadores usando DI
