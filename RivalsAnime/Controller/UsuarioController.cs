using MySql.Data.MySqlClient;
using RivalsAnime.Database;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RivalsAnime.Controller
{
    public class UsuarioController
    {
        public int Login(UsuarioDTO user)
        {
            Conexion con = new Conexion();
            MySqlConnection conexion = con.establecerConexion();

            if (conexion == null) return -1;

            try
            {
                using (MySqlConnection conn = conexion)
                {
                    string query = "SELECT tipo_rol FROM persona WHERE nombre_usuario=@u AND password_hash=@p";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", user.Usuario);
                    cmd.Parameters.AddWithValue("@p", user.Password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result); // devuelve rol
                    }
                    else
                    {
                        return 0; // login incorrecto
                    }
                }
            }
            catch (Exception)
            {
                return -1; // error
            }
        }
        public bool Registrar(UsuarioDTO user)
        {
            Conexion con = new Conexion();

            using (MySqlConnection conn = con.establecerConexion())
            {
                if (conn == null) return false;

                // comprobar si existe
                string check = "SELECT COUNT(*) FROM persona WHERE nombre_usuario=@u";
                MySqlCommand checkCmd = new MySqlCommand(check, conn);
                checkCmd.Parameters.AddWithValue("@u", user.Usuario);

                int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existe > 0)
                {
                    return false;
                }

                // insertar
                string query = "INSERT INTO persona (nombre_usuario, password_hash, tipo_rol) VALUES (@u, @p, @r)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", user.Usuario);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Rol);

                cmd.ExecuteNonQuery();

                return true;
            }
        }
    }
}
