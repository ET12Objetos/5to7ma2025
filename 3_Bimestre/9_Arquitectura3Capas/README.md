# Arquitectura de 3 Capas - Proyecto de Gestión de Usuarios

Este proyecto implementa una arquitectura de software de 3 capas (Three-Layer Architecture) que separa las responsabilidades del sistema en capas bien definidas, siguiendo los principios de separación de responsabilidades y bajo acoplamiento.

## 📋 Tabla de Contenidos

- [Arquitectura del Proyecto](#arquitectura-del-proyecto)
- [Estructura de Capas](#estructura-de-capas)
- [Capa de Aplicación](#capa-de-aplicación)
- [Capa de Tests](#capa-de-tests)
- [Capa de WebAPI](#capa-de-webapi)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Ejecución del Proyecto](#ejecución-del-proyecto)

## 🏗️ Arquitectura del Proyecto

La arquitectura de 3 capas separa el sistema en:

1. **Capa de Presentación (WebAPI)**: Maneja la interfaz con el usuario/cliente
2. **Capa de Lógica de Negocio (Aplicacion)**: Contiene las reglas de negocio y operaciones
3. **Capa de Acceso a Datos**: Implementada a través de repositorios (simulados en memoria)

```
┌─────────────────────────────────────────┐
│           WebAPI (Presentación)         │
│  - Controllers                          │
│  - DTOs                                 │
│  - Configuración API                    │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│        Aplicacion (Lógica Negocio)      │
│  - Servicios                            │
│  - Repositorios                         │
│  - Interfaces                           │
│  - Entidades                            │
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

## 🔧 Estructura de Capas

### 📁 Capa de Aplicación (`Aplicacion/`)

Esta capa contiene toda la lógica de negocio y las entidades del dominio.

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
**Propósito**: Define contratos que deben implementar las clases de infraestructura.

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
    // ... otros métodos
}
```

**Principios**:
- ✅ Define qué se puede hacer, no cómo se hace
- ✅ Facilita el testing con mocks
- ✅ Permite intercambiar implementaciones
- ✅ Invierte las dependencias

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

### 📁 Capa de WebAPI (`WebAPI/`)

Capa de presentación que expone la funcionalidad a través de una API REST.

**Tipos de componentes que debe contener**:
- **Controllers**: Manejan las peticiones HTTP
- **DTOs**: Objetos de transferencia de datos
- **Middlewares**: Componentes transversales
- **Configuración**: Setup de la aplicación

**Estructura típica**:
```
WebAPI/
├── Controllers/           # Controladores de la API
├── DTOs/                 # Objetos de transferencia
├── Middlewares/          # Componentes transversales
├── Program.cs            # Punto de entrada
└── appsettings.json      # Configuración
```

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
dotnet run --project WebAPI
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
Cliente → WebAPI Controller → Servicio → Repositorio → Datos
       ←                   ←          ←             ←
```

Esta arquitectura garantiza un código mantenible, testeable y escalable, siguiendo las mejores prácticas de desarrollo de software.
