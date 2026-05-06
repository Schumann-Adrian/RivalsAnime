using MySql.Data.MySqlClient;
using RivalsAnime.Database;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RivalsAnime.Controller
{
    public class PersonajeController()
    {
    public bool CrearPersonaje(PersonajeDTO p)
        {
            Conexion con = new Conexion();

            using (MySqlConnection conn = con.establecerConexion())
            {
                if (conn == null) return false;

                string query = @"INSERT INTO personaje 
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
        }
    }
}
