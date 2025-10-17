# API Documentation con Swagger y Scalar

Este proyecto implementa una arquitectura de tres capas con documentación automática de API utilizando **Swagger** y **Scalar**. A continuación se explica cómo se configuró cada herramienta.

## Tabla de Contenidos

- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Configuración de Paquetes NuGet](#configuración-de-paquetes-nuget)
- [Configuración de Swagger](#configuración-de-swagger)
- [Configuración de Scalar](#configuración-de-scalar)
- [Configuración de OpenAPI](#configuración-de-openapi)
- [Cómo Ejecutar](#cómo-ejecutar)
- [URLs de Documentación](#urls-de-documentación)
- [Estructura del Proyecto](#estructura-del-proyecto)

## Tecnologías Utilizadas

- **.NET 9.0**
- **ASP.NET Core Minimal APIs**
- **Swagger/OpenAPI** para documentación interactiva
- **Scalar** como alternativa moderna a Swagger UI
- **Arquitectura de 3 capas** (Presentación, Dominio, Datos)

## Configuración de Paquetes NuGet

Los siguientes paquetes fueron agregados al proyecto `Presentacion.csproj`:

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.8" />    
<PackageReference Include="Scalar.AspNetCore" Version="2.1.13" />    
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```

### Instalación de Paquetes

Para instalar estos paquetes, ejecuta los siguientes comandos en la terminal:

```bash
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.8
dotnet add package Scalar.AspNetCore --version 2.1.13
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
```

## Configuración de Swagger

### 1. Importación de Namespaces

En `Program.cs` se importaron los namespaces necesarios:

```csharp
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
```

### 2. Configuración de Servicios

Se agregaron los servicios necesarios en el builder:

```csharp
// Configuración de OpenApi (Obligatorio)
builder.Services.AddOpenApi();

//Configuración de Swagger
builder.Services.AddSwaggerGen();
```

### 3. Configuración del Middleware

Se configuró el middleware de Swagger en la aplicación:

```csharp
//Configurar OpenApi (obligatorio)
app.MapOpenApi();

//Configurar Swagger UI (Opcional)
app.UseSwagger();
app.UseSwaggerUI(x => x.EnableTryItOutByDefault());
```

**Características de Swagger UI:**
- `EnableTryItOutByDefault()`: Habilita automáticamente el botón "Try it out" en todos los endpoints
- Interfaz clásica y ampliamente conocida
- Permite probar los endpoints directamente desde la documentación

## Configuración de Scalar

Scalar es una alternativa moderna y más elegante a Swagger UI.

### 1. Configuración del Servicio

Scalar utiliza la misma configuración OpenAPI base:

```csharp
// Configuración de OpenApi (Obligatorio)
builder.Services.AddOpenApi();
```

### 2. Configuración del Middleware

Se agregó el mapeo de Scalar:

```csharp
//Configurar Scalar (Opcional)
app.MapScalarApiReference();
```

**Características de Scalar:**
- Interfaz moderna y elegante
- Mejor experiencia de usuario
- Renderizado más rápido
- Soporte completo para OpenAPI 3.0
- Diseño responsive

## Configuración de OpenAPI

OpenAPI es la especificación base que utilizan tanto Swagger como Scalar:

```csharp
// En Program.cs - Servicios
builder.Services.AddOpenApi();

// En Program.cs - Middleware  
app.MapOpenApi();
```

Esta configuración genera automáticamente la especificación OpenAPI basada en los endpoints definidos.

## Cómo Ejecutar

1. **Clonar el repositorio**
   ```bash
   git clone <url-del-repositorio>
   cd 02_ApiDocumention
   ```

2. **Restaurar dependencias**
   ```bash
   cd Presentacion
   dotnet restore
   ```

3. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

4. **Acceder a la aplicación**
   - HTTP: `http://localhost:5124`
   - HTTPS: `https://localhost:7005`

## URLs de Documentación

Una vez que la aplicación esté ejecutándose, puedes acceder a:

### Swagger UI
```
https://localhost:7005/swagger
```
o
```
http://localhost:5124/swagger
```

### Scalar UI
```
https://localhost:7005/scalar/v1
```
o
```
http://localhost:5124/scalar/v1
```

### OpenAPI JSON
```
https://localhost:7005/openapi/v1.json
```
o
```
http://localhost:5124/openapi/v1.json
```

## Estructura del Proyecto

```
ArquitecturaCapas/
├── Presentacion/           # Capa de presentación (API)
│   ├── Endpoints/         
│   │   └── ClienteEndpoints.cs
│   ├── Program.cs         # Configuración principal
│   └── Presentacion.csproj
├── Dominio/               # Capa de dominio (Lógica de negocio)
│   ├── Entidades/
│   ├── Interfaces/
│   └── Servicios/
└── Datos/                 # Capa de datos (Repositorios)
    └── Repositorios/
```

## Endpoints Disponibles

La API incluye los siguientes endpoints para la gestión de clientes:

- `GET /clientes` - Obtener todos los clientes
- `GET /clientes/{id}` - Obtener un cliente por ID
- `POST /clientes` - Crear un nuevo cliente
- `PUT /clientes/{id}` - Actualizar un cliente existente
- `DELETE /clientes/{id}` - Eliminar un cliente

## Ventajas de esta Configuración

### Swagger UI
- Interfaz familiar y estable
- Amplio soporte de la comunidad
- Funcionalidad "Try it out" integrada
- Exportación de especificaciones

### Scalar
- Interfaz moderna y atractiva
- Mejor rendimiento
- Diseño responsive
- Experiencia de usuario mejorada

### Ambas Herramientas
- Generación automática de documentación
- Soporte completo para OpenAPI 3.0
- Prueba interactiva de endpoints
- Fácil mantenimiento y actualización

## Notas Importantes

1. **OpenAPI es obligatorio** - Es la base para ambas herramientas de documentación
2. **Ambas herramientas pueden coexistir** - Puedes usar Swagger y Scalar simultáneamente
3. **Configuración mínima** - La documentación se genera automáticamente basada en los endpoints
4. **Desarrollo vs Producción** - Considera deshabilitar estas herramientas en producción por seguridad

---

Este proyecto demuestra cómo integrar múltiples herramientas de documentación de API en una arquitectura .NET moderna, proporcionando flexibilidad y opciones tanto para desarrolladores como para usuarios finales.