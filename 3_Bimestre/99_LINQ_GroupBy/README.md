# TemasVarios - Ejemplo de manejo de películas en C#

Este proyecto es una aplicación de consola en C# que muestra cómo trabajar con listas de objetos, serialización a JSON y agrupamiento de datos usando LINQ.

## Estructura principal
- **Pelicula.cs**: Contiene la clase `Pelicula` con los atributos `Nombre`, `Genero` y `AnioEstreno`.
- **Program.cs**: Archivo principal donde se crea una lista de películas, se serializa a JSON y se agrupan por género.

## ¿Qué hace el programa?
1. **Crea una lista de películas**: Cada película tiene nombre, género (sin acentos) y año de estreno.
2. **Serializa la lista a JSON**: Muestra la lista completa en formato JSON bonito por consola.
3. **Agrupa las películas por género**: Utiliza LINQ para agrupar las películas por género y muestra el resultado en formato JSON.

## Ejemplo de salida
```json
[
  {
    "Nombre": "El Padrino",
    "Genero": "Crimen",
    "AnioEstreno": 1972
  },
  ...
]

Películas agrupadas por género:
[
  {
    "Genero": "Crimen",
    "Peliculas": ["El Padrino", "Pulp Fiction"]
  },
  ...
]
```
