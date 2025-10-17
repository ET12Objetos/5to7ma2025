# JWT Implementation - Documentación Completa

## Resumen de la Implementación

Este proyecto implementa autenticación JWT (JSON Web Tokens) en una arquitectura de tres capas con .NET 9. El usuario se identifica únicamente por **email**, **rol** y **password**.

---

## Cambios Detallados por Archivo

### **1. Dominio/Entidades/Usuario.cs**
**Cambios realizados:**
- **Campos:** `Id`, `Email`, `Password`, `Rol`
- **Validaciones:** Email obligatorio y formato válido, password mínimo 6 caracteres
- **Rol por defecto:** "User"

```csharp
public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;     // Identificador principal
    public string Password { get; set; } = string.Empty;
    public string Rol { get; set; } = "User";            // Admin o User
}
```

### **2. Dominio/Entidades/AuthModels.cs**
**Cambios realizados:**
- **LoginRequest:** Solo `Email` y `Password`
- **LoginResponse:** `Token`, `Email`, `Rol`
- **RegisterRequest:** Solo `Email` y `Password`

```csharp
public class LoginRequest
{
    public string Email { get; set; } = string.Empty;     // Identificador principal
    public string Password { get; set; } = string.Empty;
}
```

### **3. Dominio/Interfaces/IUsuarioRepository.cs**
**Cambios realizados:**
- **GetByEmail()** como método principal de búsqueda
- **Simplificado:** Solo 3 métodos esenciales

```csharp
public interface IUsuarioRepository
{
    Usuario? GetByEmail(string email);    // Buscar por email únicamente
    Usuario Create(Usuario usuario);
    IEnumerable<Usuario> GetAll();
}
```

### **4. Datos/Repositorios/UsuarioRepository.cs**
**Cambios realizados:**
- **Usuarios de prueba actualizados:**
  - Admin: `admin@mail.com` / `pass123`
  - User: `usuario@mail.com` / `pass123`
- **Simplificado:** Solo búsqueda por email con `StringComparison.OrdinalIgnoreCase`

### **5. Dominio/Servicios/AuthService.cs**
**Cambios realizados:**
- **Claims del JWT:**
  - `ClaimTypes.NameIdentifier`: ID del usuario
  - `ClaimTypes.Email`: Email del usuario
  - `ClaimTypes.Role`: Rol del usuario
- **Login:** Busca por email
- **Register:** Solo requiere email y password

### **6. Presentacion/Endpoints/AuthEndpoints.cs**
**Cambios realizados:**
- **Endpoints simplificados:** Solo manejan email
- **Response del registro:** Solo retorna `Id`, `Email`, `Rol`
- **Validación:** Verifica duplicados por email únicamente

### **7. Presentacion/Program.cs**
**Cambios realizados:**
- **JWT Configuration:** Completa configuración de autenticación JWT
- **Middleware:** `UseAuthentication()` y `UseAuthorization()`
- **Swagger:** Configurado con soporte para Bearer tokens
- **Dependency Injection:** Todos los servicios de autenticación registrados

### **8. Presentacion/appsettings.json**
**Cambios realizados:**
- **Configuración JWT agregada:**
  - `SecretKey`: Clave segura de 32+ caracteres
  - `Issuer`: Identificador del emisor
  - `Audience`: Identificador de la audiencia
  - `ExpirationHours`: 24 horas

---

## Usuarios de Prueba

- **Admin**: `admin@mail.com` / `pass123`
- **Usuario regular**: `usuario@mail.com` / `pass123`

---

## Endpoints de la API

### **Autenticación**

#### 1. Login
```http
POST /auth/login
Content-Type: application/json

{
  "email": "admin@mail.com",
  "password": "pass123"
}
```

#### 2. Registro
```http
POST /auth/register
Content-Type: application/json

{
  "email": "nuevo@mail.com",
  "password": "password123"
}
```

### **Clientes (Protegidos)**

#### 3. Obtener clientes
```http
GET /clientes
Authorization: Bearer {token}
```

#### 4. Crear cliente
```http
POST /clientes
Authorization: Bearer {token}
Content-Type: application/json

{
  "id": 0,
  "nombre": "Cliente Nuevo",
  "email": "cliente@ejemplo.com"
}
```

#### 5. Eliminar cliente (Solo Admin)
```http
DELETE /clientes/1
Authorization: Bearer {token_admin}
```

---

## Paquetes NuGet Agregados

- `Microsoft.AspNetCore.Authentication.JwtBearer` (Presentación)
- `System.IdentityModel.Tokens.Jwt` (Dominio)

---

## Características de Seguridad

- **Identificación por Email:** El email es el identificador único
- **Tokens JWT seguros:** Con secreto, issuer y audience
- **Autorización por roles:** Admin vs User
- **Validación automática:** Middleware integrado
- **Swagger con JWT:** Interfaz de pruebas completa
- **Hash de contraseñas:** Implementación básica (mejorable con BCrypt)

---

## Flujo de Uso

1. **Hacer login** con email y password
2. **Recibir JWT token** válido por 24 horas
3. **Incluir token** en header: `Authorization: Bearer {token}`
4. **Acceder a endpoints protegidos**
5. **Swagger UI disponible** en: `http://localhost:5124/swagger`

---

## Notas de Producción

- **Hash de contraseñas:** Implementar BCrypt en lugar del hash básico actual
- **HTTPS:** Configurar certificados SSL para producción
- **Base de datos:** Reemplazar repository en memoria por Entity Framework
- **Logging:** Implementar logging de eventos de seguridad
