using MySql.Data.MySqlClient;
using RivalsAnime.Database;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RivalsAnime.Controller
{
    public class PersonajeController
    {
        // 🟢 CREAR NORMAL (LO DEJAS COMO ESTÁ)
        public bool CrearPersonaje(PersonajeDTO p)
        {
            Conexion con = new Conexion();
            MySqlConnection conn = con.establecerConexion();

            if (conn == null) return false;

            try
            {
                string query = @"INSERT INTO personajes
                (nombre, vida_base, ataque_base, defensa_base, nombre_habilidad)
                VALUES (@n, @v, @a, @d, @h)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@v", p.Vida);
                cmd.Parameters.AddWithValue("@a", p.Ataque);
                cmd.Parameters.AddWithValue("@d", p.Defensa);
                cmd.Parameters.AddWithValue("@h", p.Habilidad);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
                return false;
            }
        }

        // 🔥 NUEVO → CREAR O ACTUALIZAR (PARA JSON)
        public bool CrearOActualizarPersonaje(PersonajeDTO p)
        {
            Conexion con = new Conexion();
            MySqlConnection conn = con.establecerConexion();

            if (conn == null) return false;

            try
            {
                string query = @"INSERT INTO personajes
                (nombre, vida_base, ataque_base, defensa_base, nombre_habilidad)
                VALUES (@n, @v, @a, @d, @h)
                ON DUPLICATE KEY UPDATE
                    vida_base = @v,
                    ataque_base = @a,
                    defensa_base = @d,
                    nombre_habilidad = @h";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@v", p.Vida);
                cmd.Parameters.AddWithValue("@a", p.Ataque);
                cmd.Parameters.AddWithValue("@d", p.Defensa);
                cmd.Parameters.AddWithValue("@h", p.Habilidad);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error JSON: " + ex.Message);
                return false;
            }
        }

        // 🟢 LEER (LO DEJAS IGUAL)
        public List<PersonajeDTO> ObtenerPersonajes()
        {
            List<PersonajeDTO> lista = new List<PersonajeDTO>();

            Conexion con = new Conexion();
            MySqlConnection conn = con.establecerConexion();

            if (conn == null) return lista;

            try
            {
                string query = "SELECT * FROM personajes";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonajeDTO p = new PersonajeDTO()
                    {
                        Nombre = reader["nombre"].ToString(),
                        Vida = Convert.ToInt32(reader["vida_base"]),
                        Ataque = Convert.ToInt32(reader["ataque_base"]),
                        Defensa = Convert.ToInt32(reader["defensa_base"]),
                        Habilidad = reader["nombre_habilidad"].ToString()
                    };

                    lista.Add(p);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }

            return lista;
        }
        public bool ActualizarPersonaje(PersonajeDTO p)
        {
            Conexion con = new Conexion();

            using (MySqlConnection conn = con.establecerConexion())
            {
                if (conn == null) return false;

                try
                {
                    string query = @"UPDATE personajes 
            SET vida_base = @v,
                ataque_base = @a,
                defensa_base = @d,
                nombre_habilidad = @h
            WHERE nombre = @n";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@n", p.Nombre);
                    cmd.Parameters.AddWithValue("@v", p.Vida);
                    cmd.Parameters.AddWithValue("@a", p.Ataque);
                    cmd.Parameters.AddWithValue("@d", p.Defensa);
                    cmd.Parameters.AddWithValue("@h", p.Habilidad);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // 🔥 comprobar si realmente se actualizó algo
                    return filasAfectadas > 0;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Nombre duplicado ❌");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar: " + ex.Message);
                    }
                    return false;
                }
            }
        }
        public bool EliminarPersonaje(string nombre)
        {
            Conexion con = new Conexion();

            using (MySqlConnection conn = con.establecerConexion())
            {
                if (conn == null) return false;

                try
                {
                    string query = "DELETE FROM personajes WHERE nombre = @n";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", nombre);

                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                    return false;
                }
            }
        }
    }
}