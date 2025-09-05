# WebAPI - Proyecto de API Web Simple

## Descripción

Este es un proyecto de Web API desarrollado en **ASP.NET Core 9.0** que implementa una API REST minimalista con endpoints básicos de saludo y información personal. El proyecto utiliza el patrón de APIs mínimas (Minimal APIs) introducido en .NET 6 y mejorado en versiones posteriores.

## Tecnologías Utilizadas

- **.NET 9.0**: Framework principal
- **ASP.NET Core**: Para el desarrollo de la Web API
- **C#**: Lenguaje de programación
- **Microsoft.AspNetCore.OpenApi**: Para documentación automática de la API

## Estructura del Proyecto

```
WebAPI/
├── Program.cs                      # Punto de entrada principal de la aplicación
├── WebAPI.csproj                   # Archivo de proyecto .NET
├── WebAPI.http                     # Archivo de pruebas HTTP
├── appsettings.json               # Configuración de producción
├── appsettings.Development.json   # Configuración de desarrollo
├── Properties/
│   └── launchSettings.json       # Configuración de inicio del proyecto
├── bin/                          # Archivos compilados
└── obj/                          # Archivos temporales de compilación
```

## Código Fuente Principal

### Program.cs

El archivo `Program.cs` contiene toda la lógica de la aplicación usando el patrón de APIs mínimas:

```csharp
var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/bienvenida", () => "Hola mundo");

app.MapGet("/bienvenida/ingles", () => "Hello world!");

app.MapGet("/me", () =>
{
    Console.WriteLine("Hola desde servidor");
    return Results.Ok(new { nombre = "Jonathan Velazquez" });
});

app.Run();
```

#### Explicación del Código:

1. **Inicialización de la aplicación**:
   ```csharp
   var app = WebApplication.CreateBuilder(args).Build();
   ```
   - Crea una nueva instancia de la aplicación web usando el builder pattern
   - Configura automáticamente los servicios básicos necesarios

2. **Endpoint de bienvenida en español**:
   ```csharp
   app.MapGet("/bienvenida", () => "Hola mundo");
   ```
   - **Ruta**: `GET /bienvenida`
   - **Función**: Retorna un saludo simple en español
   - **Respuesta**: Texto plano "Hola mundo"

3. **Endpoint de bienvenida en inglés**:
   ```csharp
   app.MapGet("/bienvenida/ingles", () => "Hello world!");
   ```
   - **Ruta**: `GET /bienvenida/ingles`
   - **Función**: Retorna un saludo simple en inglés
   - **Respuesta**: Texto plano "Hello world!"

4. **Endpoint de información personal**:
   ```csharp
   app.MapGet("/me", () =>
   {
       Console.WriteLine("Hola desde servidor");
       return Results.Ok(new { nombre = "Jonathan Velazquez" });
   });
   ```
   - **Ruta**: `GET /me`
   - **Función**: Retorna información personal del desarrollador
   - **Logging**: Imprime un mensaje en la consola del servidor
   - **Respuesta**: Objeto JSON con el nombre del desarrollador

5. **Inicio de la aplicación**:
   ```csharp
   app.Run();
   ```
   - Inicia el servidor web y mantiene la aplicación en ejecución

## Endpoints Disponibles

| Método | Ruta | Descripción | Respuesta |
|--------|------|-------------|-----------|
| GET | `/bienvenida` | Saludo en español | `"Hola mundo"` |
| GET | `/bienvenida/ingles` | Saludo en inglés | `"Hello world!"` |
| GET | `/me` | Información personal | `{"nombre": "Jonathan Velazquez"}` |

## Configuración

### Puertos de Desarrollo

Según `launchSettings.json`, la aplicación se ejecuta en:
- **HTTP**: `http://localhost:5179`
- **HTTPS**: `https://localhost:7121`

### Variables de Entorno

- `ASPNETCORE_ENVIRONMENT`: Configurada como "Development" para el entorno de desarrollo

### Probar los Endpoints

Una vez que la aplicación esté ejecutándose, puedes probar los endpoints:

```bash
# Saludo en español
curl http://localhost:5179/bienvenida

# Saludo en inglés
curl http://localhost:5179/bienvenida/ingles

# Información personal
curl http://localhost:5179/me
```

## Características del Proyecto

### APIs Mínimas
- Utiliza el patrón de Minimal APIs de ASP.NET Core
- Código conciso y legible
- Configuración simplificada sin controladores tradicionales

### Respuestas Tipadas
- Utiliza `Results.Ok()` para respuestas HTTP estructuradas
- Serialización automática de objetos a JSON
