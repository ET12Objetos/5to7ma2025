# Tests Unitarios con .NET

Este proyecto demuestra cómo crear una solución con biblioteca de clases y tests unitarios usando xUnit.

## Comandos para crear el proyecto desde cero

### 1. Crear archivo de solución
```bash
dotnet new sln -n TestsUnitarios
```

### 2. Crear proyecto de biblioteca de clases
```bash
dotnet new classlib -n Aplicacion
```

### 3. Crear proyecto de tests con xUnit
```bash
dotnet new xunit -n Tests
```

### 4. Agregar proyectos a la solución
```bash
dotnet sln add Aplicacion/Aplicacion.csproj
dotnet sln add Tests/Tests.csproj
```

### 5. Agregar referencia del proyecto de aplicación al proyecto de tests
```bash
dotnet add Tests/Tests.csproj reference Aplicacion/Aplicacion.csproj
```

### 6. Ejecutar los tests
```bash
dotnet test
```

### 7. Compilar toda la solución
```bash
dotnet build
```

## Estructura del proyecto
```
TestsUnitarios/
├── TestsUnitarios.sln
├── Aplicacion/
│   ├── Aplicacion.csproj
│   └── Class1.cs
└── Tests/
    ├── Tests.csproj
    └── UnitTest1.cs
```

## Dependencias incluidas
- **xUnit**: Framework de testing para .NET
- **xunit.runner.visualstudio**: Para integración con Visual Studio y VS Code
- **Microsoft.NET.Test.Sdk**: SDK para ejecutar tests