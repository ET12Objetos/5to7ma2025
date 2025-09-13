using Microsoft.AspNetCore.Mvc;
using MinimalApiPut;
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

//Endpoint para crear un cliente con validación usando Data Annotations
app.MapPost("/clientes_dataAnnotation", ([FromBody] Cliente cliente) =>
{
    #region Validación usando Data Annotations
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
    #endregion

    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});

//Endpoint para actualizar un cliente con validación usando Data Annotations
app.MapPut("/clientes/{id}", (int id, Cliente clienteActualizado) =>
{
    #region Validación usando Data Annotations
    var validationContext = new ValidationContext(clienteActualizado);
    var validationResults = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(clienteActualizado, validationContext, validationResults, true);
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
    #endregion

    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    if (cliente is null)
    {
        return Results.NotFound();
    }
    cliente.Nombre = clienteActualizado.Nombre;
    cliente.Email = clienteActualizado.Email;
    return Results.Ok(cliente);
});


app.Run();
