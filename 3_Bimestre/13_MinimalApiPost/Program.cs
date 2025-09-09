using Microsoft.AspNetCore.Mvc;
using MinimalApiPost;
using System.ComponentModel.DataAnnotations;

var app = WebApplication.CreateBuilder(args).Build();

app.UseHttpsRedirection();

var clientes = new List<Cliente>
{
    new Cliente { Id = 1, Nombre = "Juan", Email = "jose@email.com" },
    new Cliente { Id = 2, Nombre = "Maria", Email = "marcela@email.com" },
    new Cliente { Id = 3, Nombre = "Jonathan", Email = "jonathan@email.com" }
};

app.MapGet("/clientes", () => clientes);

#region POST sin validación
app.MapPost("/clientes", ([FromBody] Cliente cliente) =>
{
    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});
#endregion

#region POST con validación usando clase estática
app.MapPost("/clientes_staticClass", ([FromBody] Cliente cliente) =>
{
    var errores = new Dictionary<string, string[]>();

    // Validar Id usando la clase estática
    var idError = ClienteValidator_StaticClass.ValidateId(cliente.Id);
    if (idError != null)
        errores["Id"] = new[] { idError };

    // Validar Nombre usando la clase estática
    var nombreError = ClienteValidator_StaticClass.ValidateNombre(cliente.Nombre);
    if (nombreError != null)
        errores["Nombre"] = new[] { nombreError };

    // Validar Email usando la clase estática
    var emailError = ClienteValidator_StaticClass.ValidateEmail(cliente.Email);
    if (emailError != null)
        errores["Email"] = new[] { emailError };

    // Si hay errores, devolver ValidationProblem
    if (errores.Any())
    {
        return Results.ValidationProblem(errores);
    }

    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});
#endregion

#region POST con validación usando Data Annotations
app.MapPost("/clientes_dataAnnotation", ([FromBody] Cliente cliente) =>
{
    var validationContext = new ValidationContext(cliente);
    var validationResults = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
    if (!isValid)
    {
        var errores = validationResults
            .GroupBy(e => e.MemberNames.FirstOrDefault() ?? "Error")
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage ?? "Error de validación").ToArray()
            );
        return Results.ValidationProblem(errores);
    }
    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});
#endregion

#region POST con validación usando FluentValidation
app.MapPost("/clientes_fluentValidation", ([FromBody] Cliente cliente) =>
{
    var validator = new ClienteValidator_FluentValidation();
    var validationResult = validator.Validate(cliente);

    if (!validationResult.IsValid)
    {
        var errores = validationResult.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()
            );
        return Results.ValidationProblem(errores);
    }

    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});
#endregion

app.Run();