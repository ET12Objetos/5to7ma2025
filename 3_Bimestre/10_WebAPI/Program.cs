var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/bienvenida", () => "Hola mundo");

app.MapGet("/bienvenida/ingles", () => "Hello world!");

app.MapGet("/me", () =>
{
    Console.WriteLine("Hola desde servidor");
    return Results.Ok(new { nombre = "Jonathan Velazquez" });
});

app.Run();
