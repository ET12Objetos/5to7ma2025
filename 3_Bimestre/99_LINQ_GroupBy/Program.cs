
using TemasVarios;
using System.Text.Json;

List<Pelicula> peliculas = new List<Pelicula>
{
    new Pelicula { Nombre = "El Padrino", Genero = "Crimen", AnioEstreno = 1972 },
    new Pelicula { Nombre = "Forrest Gump", Genero = "Drama", AnioEstreno = 1994 },
    new Pelicula { Nombre = "En busca de la felicidad", Genero = "Drama", AnioEstreno = 2006 },
    new Pelicula { Nombre = "La vida es bella", Genero = "Drama", AnioEstreno = 1997 },
    new Pelicula { Nombre = "Inception", Genero = "Ciencia Ficcion", AnioEstreno = 2010 },
    new Pelicula { Nombre = "El Señor de los Anillos: La Comunidad del Anillo", Genero = "Fantasia", AnioEstreno = 2001 },
    new Pelicula { Nombre = "Harry Potter y la piedra filosofal", Genero = "Fantasia", AnioEstreno = 2001 },
    new Pelicula { Nombre = "Pulp Fiction", Genero = "Crimen", AnioEstreno = 1994 },
    new Pelicula { Nombre = "Matrix", Genero = "Ciencia Ficcion", AnioEstreno = 1999 },
};

var opcionesJson = new JsonSerializerOptions { WriteIndented = true };
string peliculasJson = JsonSerializer.Serialize(peliculas, opcionesJson);
Console.WriteLine(peliculasJson);

Console.ReadKey();
Console.Clear();

// Peliculas agrupadas por género
var peliculasPorGenero = peliculas
    .GroupBy(p => p.Genero)
    .Select(g => new
    {
        Genero = g.Key,
        Peliculas = g.Select(p => p.Nombre).ToList()
    });

string groupByGeneroJson = JsonSerializer.Serialize(peliculasPorGenero, opcionesJson);
Console.WriteLine("\nPelículas agrupadas por género:\n" + groupByGeneroJson);
