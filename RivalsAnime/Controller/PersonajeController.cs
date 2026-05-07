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

                reader.Close(); // 🔥 importante
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }

            return lista;
        }
    }
}