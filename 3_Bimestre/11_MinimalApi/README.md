# Proyecto MinimalAPI en ASP.NET Core

Este proyecto es un ejemplo de cómo implementar una API REST utilizando la arquitectura Minimal API de ASP.NET Core. Las Minimal APIs son una forma simplificada de crear APIs web en .NET, con un código más conciso y menos ceremonial que los controladores tradicionales.

## Estructura del Proyecto

- `Program.cs`: Archivo principal que contiene la configuración y definición de los endpoints de la API.
- `Cliente.cs`: Modelo de datos que representa un cliente.
- `MinimalAPI.http`: Archivo para realizar pruebas HTTP a los endpoints de la API.
- `Properties/launchSettings.json`: Configuración de lanzamiento de la aplicación.

## Tecnologías Utilizadas

- .NET 9.0
- ASP.NET Core
- Minimal API

## Endpoints Disponibles

El proyecto implementa varios endpoints para demostrar diferentes formas de devolver datos en una Minimal API:

1. **GET /bienvenida**
   - Devuelve un simple mensaje de texto "Hola mundo!"
   - Ejemplo de retorno directo de un string.

2. **GET /objetoanonimo**
   - Devuelve un objeto anónimo: `{ Mensaje = "Hola mundo!" }`
   - Ejemplo de cómo retornar objetos anónimos sin necesidad de crear clases específicas.

3. **GET /cliente1**
   - Devuelve un objeto de tipo `Cliente` con Id=1 y Nombre="Juan"
   - Ejemplo de retorno de un objeto de una clase definida.

4. **GET /cliente2**
   - Devuelve una respuesta 404 (Not Found) con un objeto `Cliente` con Id=2 y Nombre="Jose"
   - Ejemplo de uso del objeto `Results` para controlar el código de estado HTTP.

## Modelo de Datos

El proyecto incluye un modelo simple:

### Cliente
```csharp
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
```

## Configuración

La aplicación está configurada para ejecutarse en:
- HTTP: http://localhost:5090
- HTTPS: https://localhost:7230

## Cómo Ejecutar

1. Asegúrate de tener instalado .NET 9.0 SDK
2. Navega hasta el directorio del proyecto
3. Ejecuta el siguiente comando:

```bash
dotnet run
```

4. La API estará disponible en http://localhost:5090

## Características de Minimal API

Las Minimal APIs ofrecen varias ventajas:

- Código más conciso y enfocado
- Menos ceremonial y archivos que en los controladores tradicionales
- Ideal para microservicios y APIs simples
- Mejor rendimiento debido a menos sobrecarga

Este proyecto demuestra cómo implementar una API simple utilizando este enfoque moderno de desarrollo en ASP.NET Core.
