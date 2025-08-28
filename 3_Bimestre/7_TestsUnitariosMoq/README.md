# 🧪 Guía Completa de Moq - Testing con Mocks en .NET

## 📋 Tabla de Contenidos
- [¿Qué es Moq?](#qué-es-moq)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Conceptos Básicos](#conceptos-básicos)
- [Ejemplos Prácticos](#ejemplos-prácticos)
- [Características Avanzadas](#características-avanzadas)
- [Mejores Prácticas](#mejores-prácticas)
- [Troubleshooting](#troubleshooting)

## 🤔 ¿Qué es Moq?

**Moq** es una librería de mocking para .NET que permite crear objetos simulados (mocks) de interfaces y clases virtuales para realizar pruebas unitarias aisladas. Es la librería de mocking más popular en el ecosistema .NET.

### ✅ Ventajas de usar Moq:
- **Aislamiento**: Prueba componentes de forma independiente
- **Control total**: Define exactamente cómo deben comportarse las dependencias
- **Verificación**: Comprueba que las interacciones ocurrieron como se esperaba
- **Flexibilidad**: Simula diferentes escenarios sin modificar código de producción

## 📦 Instalación

### Opción 1: Package Manager Console
```powershell
Install-Package Moq
```

### Opción 2: .NET CLI (Recomendado)
```bash
dotnet add package Moq
```

### Opción 3: PackageReference en .csproj
```xml
<PackageReference Include="Moq" Version="4.20.72" />
```

## ⚙️ Configuración

### 1. Estructura de Proyecto (Recomendada por Microsoft)
```
MiProyecto/
├── MiProyecto.sln
├── src/
│   └── MiProyecto/
│       ├── MiProyecto.csproj
│       ├── Servicios/
│       │   ├── INotificadorService.cs
│       │   └── NotificadorEmailService.cs
│       └── Entidades/
│           └── Usuario.cs
└── tests/
    └── MiProyecto.Tests/
        ├── MiProyecto.Tests.csproj
        └── Servicios/
            └── NotificadorServiceTests.cs
```

### 2. Configuración del Proyecto de Tests
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.12.0" />
    <PackageReference Include="Moq" Version="4.20.72" />
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\src\MiProyecto\MiProyecto.csproj" />
  </ItemGroup>
</Project>
```

### 3. Usings Necesarios
```csharp
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
```

## 🔧 Conceptos Básicos

### 1. Crear un Mock
```csharp
// Mock de una interfaz
var mockService = new Mock<INotificadorService>();

// Mock de una clase con métodos virtuales
var mockRepository = new Mock<RepositoryBase>();
```

### 2. Configurar Comportamiento (Setup) - Para hacer uso de esto la clase debe tener una interface asociada
```csharp
// Configurar método void
mockService.Setup(s => s.Enviar(It.IsAny<string>()));

// Configurar método con retorno
mockService.Setup(s => s.ObtenerUsuario(1))
           .Returns(new Usuario { Id = 1, Nombre = "Juan" });

// Configurar propiedad
mockService.SetupGet(s => s.EstaConectado).Returns(true);
```

### 3. Verificar Interacciones
```csharp
// Verificar que se llamó exactamente una vez
mockService.Verify(s => s.Enviar("test"), Times.Once);

// Verificar que nunca se llamó
mockService.Verify(s => s.Eliminar(It.IsAny<int>()), Times.Never);

// Verificar que se llamó al menos una vez
mockService.Verify(s => s.Obtener(), Times.AtLeastOnce);
```

## 📝 Ejemplos Prácticos

### Ejemplo 1: Mock Básico de Servicio

```csharp
// Interfaz
public interface IEmailService
{
    void EnviarEmail(string destinatario, string mensaje);
    bool EstaDisponible { get; }
}

// Test
[Fact]
public void DeberiaEnviarEmailCorrectamente()
{
    // Arrange
    var mockEmailService = new Mock<IEmailService>();
    mockEmailService.SetupGet(s => s.EstaDisponible).Returns(true);
    
    var notificador = new Notificador(mockEmailService.Object);
    
    // Act
    notificador.NotificarUsuario("test@email.com", "Mensaje de prueba");
    
    // Assert
    mockEmailService.Verify(s => s.EnviarEmail("test@email.com", "Mensaje de prueba"), Times.Once);
}
```

### Ejemplo 2: Mock con Configuración en Constructor

```csharp
public class NotificadorServiceTests
{
    private readonly Mock<IEmailService> _mockEmailService;
    private readonly Mock<ISmsService> _mockSmsService;
    private readonly List<Usuario> _usuarios;

    public NotificadorServiceTests()
    {
        // Configurar mocks en constructor
        _mockEmailService = new Mock<IEmailService>();
        _mockSmsService = new Mock<ISmsService>();
        
        // Configurar datos de prueba
        _usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Email = "user1@test.com", Telefono = "123456789" },
            new Usuario { Id = 2, Email = "user2@test.com", Telefono = "987654321" }
        };
        
        // Configurar comportamiento por defecto
        _mockEmailService.Setup(s => s.EnviarEmail(It.IsAny<string>(), It.IsAny<string>()));
        _mockSmsService.Setup(s => s.EnviarSms(It.IsAny<string>(), It.IsAny<string>()));
    }

    [Fact]
    public void DeberiaEnviarNotificacionAUsuarios()
    {
        // Arrange
        var notificador = new NotificadorService(_mockEmailService.Object, _mockSmsService.Object);

        // Act
        notificador.NotificarUsuarios(_usuarios, "Mensaje importante");

        // Assert
        _mockEmailService.Verify(s => s.EnviarEmail(It.IsAny<string>(), "Mensaje importante"), Times.Exactly(2));
        _mockSmsService.Verify(s => s.EnviarSms(It.IsAny<string>(), "Mensaje importante"), Times.Exactly(2));
    }
}
```

## 🚀 Características Avanzadas

### 1. Uso de `It.Is<T>()` para Condiciones Específicas

```csharp
[Fact]
public void DeberiaValidarEmailsConFormato()
{
    // Arrange
    var mockService = new Mock<IEmailService>();
    
    // Act
    mockService.Object.EnviarEmail("test@domain.com", "mensaje");
    
    // Assert - Verificar que el email tiene formato válido
    mockService.Verify(s => s.EnviarEmail(
        It.Is<string>(email => email.Contains("@") && email.Contains(".")), 
        It.IsAny<string>()), 
        Times.Once);
}
```

### 2. Simulación de Excepciones

```csharp
[Fact]
public void DeberiaManejarExcepcionDelServicio()
{
    // Arrange
    var mockService = new Mock<IEmailService>();
    mockService.Setup(s => s.EnviarEmail(It.IsAny<string>(), It.IsAny<string>()))
               .Throws(new InvalidOperationException("Servicio no disponible"));

    var notificador = new Notificador(mockService.Object);

    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => 
        notificador.NotificarUsuario("test@email.com", "mensaje"));
}
```

### 3. Verificaciones con Timeout

```csharp
[Fact]
public void DeberiaVerificarLlamadaAsync()
{
    // Arrange
    var mockService = new Mock<IEmailService>();
    
    // Act
    Task.Run(() => mockService.Object.EnviarEmail("test@email.com", "mensaje"));
    
    // Assert - Esperar hasta 5 segundos
    mockService.Verify(s => s.EnviarEmail("test@email.com", "mensaje"), 
                      Times.Once, 
                      TimeSpan.FromSeconds(5));
}
```

## 📚 Patrones de Verificación con `Times`

```csharp
// Verificaciones básicas
Times.Never          // Nunca se llamó
Times.Once           // Exactamente una vez
Times.AtLeastOnce    // Al menos una vez
Times.AtMost(3)      // Máximo 3 veces
Times.Exactly(2)     // Exactamente 2 veces
Times.Between(1, 5, Range.Inclusive)  // Entre 1 y 5 veces

// Ejemplo de uso
mockService.Verify(s => s.Procesar(), Times.Between(2, 4, Range.Exclusive));
```

## 🎯 Mejores Prácticas

### ✅ Hacer
1. **Usa mocks solo para dependencias externas**
2. **Configura mocks en el constructor del test**
3. **Usa `It.IsAny<T>()` cuando el valor específico no importa**
4. **Verifica solo las interacciones importantes**
5. **Nombra tus tests descriptivamente**

```csharp
[Fact]
public void EnviarEmail_CuandoUsuarioValido_DeberiaLlamarServicioUnaVez()
{
    // Test bien nombrado y enfocado
}
```

### ❌ Evitar
1. **No mockees clases que no controlas (DateTime, HttpClient directamente)**
2. **No hagas over-verification (verificar todo)**
3. **No uses mocks para lógica simple**
4. **No configures comportamiento que no usas**

### 🔧 Patrón AAA (Arrange-Act-Assert)
```csharp
[Fact]
public void MetodoEjemplo()
{
    // Arrange - Configurar mocks y datos
    var mockService = new Mock<IEmailService>();
    mockService.Setup(s => s.EstaDisponible).Returns(true);
    var notificador = new Notificador(mockService.Object);

    // Act - Ejecutar la acción a probar
    var resultado = notificador.ProcesarNotificacion("mensaje");

    // Assert - Verificar resultados e interacciones
    Assert.True(resultado);
    mockService.Verify(s => s.EnviarEmail(It.IsAny<string>(), "mensaje"), Times.Once);
}
```