using MySql.Data.MySqlClient;

//Ejemplo 5 - Conexión a MySQL

string connectionString = "Server=localhost;Database=deposito;User ID=root;Password=pass123;Port=3306;";
MySqlConnection? conexion = null;

try
{
    conexion = new MySqlConnection(connectionString);
    conexion.Open();
    Console.WriteLine("Conexión exitosa a la base de datos MySQL.");

    // Consulta simple
    string querySimple = "SELECT COUNT(*) FROM producto";
    MySqlCommand cmdSimple = new MySqlCommand(querySimple, conexion);
    int totalProductos = Convert.ToInt32(cmdSimple.ExecuteScalar());
    Console.WriteLine($"Total de productos: {totalProductos}");

    System.Console.WriteLine("-----------------------------------");
    // Consulta con data
    string query = "SELECT * FROM producto";
    MySqlCommand cmd = new MySqlCommand(query, conexion);

    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        //por indice
        Console.WriteLine($"Id: {reader[0]}, Nombre: {reader[1]}");

        //por nombre
        //Console.WriteLine($"Id: {reader["Id"]}, Nombre: {reader["Nombre"]}");
    }
}
catch (MySqlException ex)
{
    Console.WriteLine($"Error al conectar o consultar: {ex.ToString()}");
}
finally
{
    if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
    {
        conexion.Close();
        Console.WriteLine("Conexión a MySQL cerrada.");
    }
}