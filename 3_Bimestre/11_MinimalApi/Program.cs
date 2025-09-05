using MinimalApi;

var app = WebApplication.CreateBuilder(args).Build();

app.UseHttpsRedirection();

// 1. Devuelve un string
app.MapGet("/bienvenida", () => "Hola mundo!");

// 2. Devuelve un objeto anónimo
app.MapGet("/objetoanonimo", () => new { Mensaje = "Hola mundo!" });

// 3. Devuelve un objeto de una clase auxiliar
app.MapGet("/cliente1", () => new Cliente { Id = 1, Nombre = "Juan" });

app.MapGet("/cliente2", () =>
{
    var cliente = new Cliente { Id = 2, Nombre = "Jose" };

    return Results.NotFound(cliente);
});

app.Run();

