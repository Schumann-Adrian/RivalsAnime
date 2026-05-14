using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace RivalsAnime.Database
{
    internal class Conexion
    {
        private string servidor = "localhost";
        private string bd = "batallaanimedb";
        private string usuario = "root"; // Usuario por defecto de HeidiSQL
        private string password = "123456789";

        public MySqlConnection? establecerConexion()
        {
            string cadenaconexion = $"server={servidor};database={bd};uid={usuario};pwd={password};";
            MySqlConnection conexion = new MySqlConnection(cadenaconexion);

            try
            {
                conexion.Open();
                return conexion;
            }
            catch
            {
                conexion.Dispose();
                return null;
            }
        }
    }
}
