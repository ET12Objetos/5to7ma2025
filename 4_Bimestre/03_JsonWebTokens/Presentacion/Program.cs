using Dominio.Interfaces;
using Dominio.Servicios;
using Datos.Repositorios;
using Presentacion.Endpoints;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["SecretKey"]!;
var issuer = jwtSettings["Issuer"]!;
var audience = jwtSettings["Audience"]!;

// Configuración de autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization();

// Configuración de OpenApi (Obligatorio)
builder.Services.AddOpenApi();

//Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService>(provider =>
{
    var usuarioRepository = provider.GetRequiredService<IUsuarioRepository>();
    return new AuthService(usuarioRepository, secretKey, issuer, audience);
});

var app = builder.Build();

app.UseHttpsRedirection();

// Configurar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

//Configurar OpenApi (obligatorio)
app.MapOpenApi();

//Configurar Scalar (Opcional)
app.MapScalarApiReference();

//Configurar Swagger UI (Opcional)
app.UseSwagger();
app.UseSwaggerUI(x => x.EnableTryItOutByDefault());

// Configurar endpoints de autenticación
app.MapAuthEndpoints();

// Configurar endpoints de Cliente
app.MapClienteEndpoints();

app.Run();
