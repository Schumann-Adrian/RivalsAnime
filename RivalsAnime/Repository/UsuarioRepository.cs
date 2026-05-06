using System;
using System.Collections.Generic;
using System.Text;

namespace RivalsAnime.Repository
{
    using MySql.Data.MySqlClient;
    using RivalsAnime.Database;
    using RivalsAnime.Model;

    public class UsuarioRepository
    {
        Conexion con = new Conexion();

        public bool ExisteUsuario(string usuario)
        {
            using (MySqlConnection conn = con.establecerConexion())
            {
                string query = "SELECT COUNT(*) FROM persona WHERE nombre_usuario=@u";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", usuario);

                int existe = Convert.ToInt32(cmd.ExecuteScalar());
                return existe > 0;
            }
        }

        public void Insertar(UsuarioDTO user)
        {
            using (MySqlConnection conn = con.establecerConexion())
            {
                string query = "INSERT INTO persona (nombre_usuario, password_hash, tipo_rol) VALUES (@u, @p, @r)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", user.Usuario);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Rol);

                cmd.ExecuteNonQuery();
            }
        }

        public int Login(UsuarioDTO user)
        {
            using (MySqlConnection conn = con.establecerConexion())
            {
                string query = "SELECT tipo_rol FROM persona WHERE nombre_usuario=@u AND password_hash=@p";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", user.Usuario);
                cmd.Parameters.AddWithValue("@p", user.Password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);

                return 0;
            }
        }
    }
}
