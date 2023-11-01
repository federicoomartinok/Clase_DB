using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDB.DB
{
    internal class Db
    {
        //public static SqlConnection connection;
        public static MySqlConnection connectionMysql;

        //public static SqlCommand commandSql;
        public static MySqlCommand commandMysql;

        static Db()
        {
            var connectionString = @"Server=localhost;Database=test;Uid=root;Pwd=;";
            connectionMysql = new MySqlConnection(connectionString);

            commandMysql = new MySqlCommand();
            commandMysql.CommandType = System.Data.CommandType.Text;
            commandMysql.Connection = connectionMysql;

        }

        public static void Insert(string nombre, string apellido)
        {
            try
            {
                connectionMysql.Open();
                commandMysql.Parameters.Clear();

                var query = $"INSERT INTO alumnos (nombre,apellido) VALUES(@nombre, @apellido)";

                commandMysql.CommandText = query ;

                commandMysql.Parameters.AddWithValue("@nombre", nombre);
                commandMysql.Parameters.AddWithValue("@apellido", apellido);


                var filasAfectadas = commandMysql.ExecuteNonQuery();

                Console.WriteLine("Filas afectadas: "+ filasAfectadas);

            }
            catch (Exception ex)
            {

            }finally 
            { 
                connectionMysql.Close(); 
            }
        }

        /*public static void Select()
        {
            try
            {
                connectionMysql.Open();
                var query = "SELECT * FROM alumnos";

                commandMysql.CommandText = query;


                using (var reader = commandMysql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nombre = reader["Nombre"].ToString();
                        var apellido = reader["Apellido"].ToString();
                        var id = Convert.ToInt32(reader["id"].ToString());
                        Console.WriteLine($"ID: {id} Nombre: {nombre} - Apellido: {apellido}");
                    }
                }

            }catch (Exception ex)
            {

            }
            finally
            {
                connectionMysql.Close();
            }
        }*/
        public static List<T> Select<T>(string query) where T : PersonaADO
        {
            var lista = new List<T>();
            try
            {
                connectionMysql.Open();
                //var query = "SELECT * FROM alumnos";

                commandMysql.CommandText = query;


                using (var reader = commandMysql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T objeto = (T)reader;

                        //lista.Add(objeto);
                        Console.WriteLine($"ID: {id} Nombre: {nombre} - Apellido: {apellido}");
                    }
                }

                return lista;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectionMysql.Close();
            }
        }

        public static void OpenConnection()
        {
            connectionMysql.Open();
            connectionMysql.Close();            
        }
    }
}
