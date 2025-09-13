# Arquitectura de 3 Capas - Proyecto de Gestión de Usuarios

Este proyecto implementa una arquitectura de software de 3 capas (Three-Layer Architecture) que separa las responsabilidades del sistema en capas bien definidas, siguiendo los principios de separación de responsabilidades y bajo acoplamiento.

## 📋 Tabla de Contenidos

- [Arquitectura del Proyecto](#arquitectura-del-proyecto)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Estructura de Capas](#estructura-de-capas)
- [Capa de Dominio](#capa-de-dominio-dominio)
- [Capa de Aplicación](#capa-de-aplicación-aplicacion)
- [Capa de Tests](#capa-de-tests-tests)
- [Capa de Presentación](#capa-de-presentación-presentacion)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Ejecución del Proyecto](#ejecución-del-proyecto)

## 🏗️ Arquitectura del Proyecto

La arquitectura de 3 capas separa el sistema en:

1. **Capa de Presentación (Presentacion)**: Maneja la interfaz con el usuario/cliente a través de Web API
2. **Capa de Lógica de Negocio (Aplicacion)**: Contiene las reglas de negocio y operaciones
3. **Capa de Dominio (Dominio)**: Define las entidades, interfaces y reglas del dominio
4. **Capa de Pruebas (Tests)**: Contiene las pruebas unitarias del sistema

```
┌─────────────────────────────────────────┐
│        Presentacion (Web API)           │
│  - Controllers                          │
│  - Program.cs                           │
│  - Configuración API                    │
│  - launchSettings.json                  │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│        Aplicacion (Lógica Negocio)      │
│  - Servicios                            │
│  - Repositorios                         │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│          Dominio (Entidades)            │
│  - Entidades                            │
│  - Interfaces                           │
│  - Enums                                │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│       Tests (Pruebas Unitarias)         │
│  - Tests de Servicios                   │
│  - Tests de Repositorios                │
│  - Mocks y Stubs                        │
└─────────────────────────────────────────┘
```

## 📁 Estructura del Proyecto

```
Arquitectura3Capas/
├── Arquitectura3Capas.sln          # Archivo de solución
├── README.md                        # Documentación del proyecto
│
├── Dominio/                         # 🎯 Capa de Dominio
│   ├── Dominio.csproj              # Archivo de proyecto
│   ├── Entidades/
│   │   └── Usuario.cs              # Entidad Usuario
│   ├── Enums/
│   │   └── EstadoUsuario.cs        # Enumeración de estados
│   └── Interfaces/
│       └── IUsuarioRepositorio.cs  # Interfaz del repositorio
│
├── Aplicacion/                      # 🔧 Capa de Aplicación
│   ├── Aplicacion.csproj           # Archivo de proyecto
│   ├── Repositorios/
│   │   └── UsuarioRepositorio.cs   # Implementación del repositorio
│   └── Servicios/
│       └── UsuarioServicio.cs      # Lógica de negocio
│
├── Presentacion/                    # 🌐 Capa de Presentación
│   ├── Presentacion.csproj         # Archivo de proyecto
│   ├── Program.cs                  # Punto de entrada de la API
│   ├── Presentacion.http           # Archivo de pruebas HTTP
│   ├── appsettings.json           # Configuración de la aplicación
│   ├── appsettings.Development.json # Configuración de desarrollo
│   └── Properties/
│       └── launchSettings.json     # Configuración de ejecución
│
└── Tests/                          # 🧪 Capa de Pruebas
    ├── Tests.csproj               # Archivo de proyecto de tests
    ├── UnitTest1.cs               # Prueba unitaria base
    └── Servicios/
        └── UsuarioServicioTests.cs # Tests del servicio de usuarios
```

## 🔧 Estructura de Capas

### 📁 Capa de Dominio (`Dominio/`)

Esta capa contiene las entidades fundamentales del dominio, las reglas de negocio más importantes y las interfaces que definen contratos para otras capas.

#### 📂 `Entidades/`
**Propósito**: Contiene las clases que representan los objetos del dominio del negocio.

**Tipos de clases que debe contener**:
- **Entidades de Dominio**: Clases que representan conceptos fundamentales del negocio
- **Value Objects**: Objetos inmutables que representan valores
- **Aggregate Roots**: Entidades principales que agrupan otras entidades relacionadas

**Ejemplo actual**:
```csharp
// Usuario.cs - Entidad principal del dominio
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public EstadoUsuario Estado { get; set; }
    // ... otras propiedades
}
```

**Características**:
- ✅ Propiedades que definen el estado del objeto
- ✅ Validaciones usando Data Annotations
- ✅ Relaciones entre entidades
- ❌ No debe contener lógica de acceso a datos
- ❌ No debe tener dependencias externas

#### 📂 `Enums/`
**Propósito**: Define enumeraciones que representan conjuntos fijos de valores para el dominio.

**Tipos de enums que debe contener**:
- **Estados de entidades**: Como `EstadoUsuario`
- **Tipos y categorías**: Para clasificar entidades
- **Constantes del dominio**: Valores fijos del negocio

**Ejemplo actual**:
```csharp
// EstadoUsuario.cs - Estados posibles de un usuario
public enum EstadoUsuario
{
    Activo = 1,
    Inactivo = 2,
    Suspendido = 3,
    Bloqueado = 4
}
```

#### 📂 `Interfaces/`
**Propósito**: Define contratos que deben implementar las clases de infraestructura y aplicación.

**Tipos de interfaces que debe contener**:
- **Interfaces de Repositorio**: Definen operaciones de acceso a datos
- **Interfaces de Servicios**: Contratos para servicios externos
- **Interfaces de Dominio**: Contratos específicos del negocio

**Ejemplo actual**:
```csharp
// IUsuarioRepositorio.cs - Contrato para acceso a datos de usuarios
public interface IUsuarioRepositorio
{
    Usuario? ObtenerPorId(int id);
    IEnumerable<Usuario> ObtenerTodos();
    Usuario Crear(Usuario usuario);
    Usuario Actualizar(Usuario usuario);
    bool Eliminar(int id);
    // ... otros métodos
}
```

**Principios**:
- ✅ Define qué se puede hacer, no cómo se hace
- ✅ Facilita el testing con mocks
- ✅ Permite intercambiar implementaciones
- ✅ Invierte las dependencias

### 📁 Capa de Aplicación (`Aplicacion/`)

Esta capa contiene la implementación de la lógica de negocio y la coordinación entre el dominio y la presentación.

#### 📂 `Repositorios/`
**Propósito**: Implementa el patrón Repository para el acceso a datos.

**Tipos de clases que debe contener**:
- **Repositorios Concretos**: Implementaciones de las interfaces de repositorio
- **Repositorios Base**: Clases base con funcionalidad común
- **Repositorios Especializados**: Para operaciones específicas de acceso a datos

**Ejemplo actual**:
```csharp
// UsuarioRepositorio.cs - Implementación del repositorio de usuarios
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly List<Usuario> _usuarios = new();
    
    public Usuario? ObtenerPorId(int id)
    {
        return _usuarios.FirstOrDefault(u => u.Id == id);
    }
    // ... implementación de métodos
}
```

**Responsabilidades**:
- ✅ Implementar operaciones CRUD
- ✅ Gestionar la persistencia de datos
- ✅ Encapsular consultas complejas
- ❌ No debe contener lógica de negocio
- ❌ No debe exponer detalles de implementación

#### 📂 `Servicios/`
**Propósito**: Contiene la lógica de negocio y coordina las operaciones entre diferentes componentes.

**Tipos de clases que debe contener**:
- **Servicios de Dominio**: Lógica de negocio específica
- **Servicios de Aplicación**: Orquestación de casos de uso
- **Servicios de Infraestructura**: Integración con sistemas externos

**Ejemplo actual**:
```csharp
// UsuarioServicio.cs - Lógica de negocio para usuarios
public class UsuarioServicio
{
    public Usuario CrearUsuario(string nombre, string email, ...)
    {
        // Validaciones de negocio
        if (_usuarioRepositorio.ExisteEmail(email))
            throw new InvalidOperationException("El email ya está en uso");
            
        // Lógica de creación
        var usuario = new Usuario { /* ... */ };
        return _usuarioRepositorio.Crear(usuario);
    }
}
```

**Responsabilidades**:
- ✅ Implementar reglas de negocio
- ✅ Validar datos de entrada
- ✅ Coordinar operaciones entre repositorios
- ✅ Manejar transacciones
- ❌ No debe acceder directamente a la base de datos

### 📁 Capa de Tests (`Tests/`)

Contiene todas las pruebas unitarias del proyecto.

#### 📂 `Servicios/`
**Propósito**: Tests para validar la lógica de negocio implementada en los servicios.

**Tipos de tests que debe contener**:
- **Tests de Casos Exitosos**: Validar comportamiento correcto
- **Tests de Casos de Error**: Validar manejo de excepciones
- **Tests de Validaciones**: Verificar reglas de negocio
- **Tests de Integración**: Entre servicios y repositorios

**Ejemplo actual**:
```csharp
// UsuarioServicioTests.cs - Tests del servicio de usuarios
[Fact]
public void CrearUsuario_DeberiaLanzarExcepcion_CuandoEmailYaExiste()
{
    // Arrange
    _mockUsuarioRepo.Setup(x => x.ExisteEmail(email)).Returns(true);
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(
        () => _usuarioServicio.CrearUsuario("Juan", "test@email.com", ...)
    );
}
```

**Características**:
- ✅ Usa mocks para aislar dependencias
- ✅ Sigue patrón Arrange-Act-Assert
- ✅ Nombrado descriptivo de métodos
- ✅ Cobertura de casos edge

### 📁 Capa de Presentación (`Presentacion/`)

Capa de presentación que expone la funcionalidad a través de una API REST.

**Tipos de componentes que debe contener**:
- **Controllers**: Manejan las peticiones HTTP
- **Program.cs**: Configuración y punto de entrada de la aplicación
- **Configuración**: Setup de la aplicación y servicios
- **Launch Settings**: Configuración de ejecución y perfiles

**Estructura actual**:
```
Presentacion/
├── Program.cs                    # Punto de entrada y configuración
├── Presentacion.http            # Archivo de pruebas HTTP
├── appsettings.json            # Configuración de la aplicación
├── appsettings.Development.json # Configuración de desarrollo
└── Properties/
    └── launchSettings.json     # Configuración de ejecución
```

**Ejemplo de configuración**:
```csharp
// Program.cs - Configuración de la aplicación
var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<UsuarioServicio>();

var app = builder.Build();

// Configurar pipeline
app.UseRouting();
app.MapControllers();

app.Run();
```

**Responsabilidades**:
- ✅ Manejar peticiones HTTP
- ✅ Validar entrada de datos
- ✅ Serializar/deserializar JSON
- ✅ Configurar servicios e inyección de dependencias
- ❌ No debe contener lógica de negocio
- ❌ No debe acceder directamente a repositorios

## 💻 Tecnologías Utilizadas

- **.NET 9.0**: Framework principal
- **C#**: Lenguaje de programación
- **xUnit**: Framework de testing
- **Moq**: Framework para mocking
- **ASP.NET Core**: Para la Web API

## 🚀 Ejecución del Proyecto

### Compilar el proyecto:
```bash
dotnet build
```

### Ejecutar tests:
```bash
dotnet test
```

### Ejecutar la API:
```bash
dotnet run --project Presentacion
```

## 📋 Principios de Arquitectura Aplicados

### ✅ **Separación de Responsabilidades**
Cada capa tiene una responsabilidad específica y bien definida.

### ✅ **Inversión de Dependencias**
Las capas superiores dependen de abstracciones (interfaces) de las capas inferiores.

### ✅ **Bajo Acoplamiento**
Los componentes están débilmente acoplados a través de interfaces.

### ✅ **Alta Cohesión**
Los elementos dentro de cada capa están fuertemente relacionados.

### ✅ **Testabilidad**
El uso de interfaces permite realizar pruebas unitarias efectivas.

## 📝 Convenciones de Nomenclatura

- **Entidades**: Nombres en singular (`Usuario`, `Producto`)
- **Repositorios**: `{Entidad}Repositorio` (`UsuarioRepositorio`)
- **Servicios**: `{Entidad}Servicio` (`UsuarioServicio`)
- **Interfaces**: `I{Nombre}` (`IUsuarioRepositorio`)
- **Tests**: `{ClaseATestear}Tests` (`UsuarioServicioTests`)

## 🔄 Flujo de Datos

```
Cliente → Presentacion (API) → Aplicacion (Servicio) → Dominio (Entidades/Interfaces) → Aplicacion (Repositorio) → Datos
       ←                    ←                        ←                                ←                        ←
```

### Flujo Detallado:

1. **Cliente** → Envía petición HTTP a la API
2. **Presentacion** → Recibe la petición y valida los datos de entrada
3. **Aplicacion (Servicio)** → Ejecuta la lógica de negocio usando entidades del dominio
4. **Dominio** → Proporciona entidades, enums e interfaces para las operaciones
5. **Aplicacion (Repositorio)** → Implementa las interfaces del dominio para acceso a datos
6. **Datos** → Almacena o recupera información (en memoria en este proyecto)

Esta arquitectura garantiza un código mantenible, testeable y escalable, siguiendo las mejores prácticas de desarrollo de software.
