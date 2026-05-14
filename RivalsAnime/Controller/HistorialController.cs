using MySql.Data.MySqlClient;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;

namespace RivalsAnime.Controller
{
    internal class HistorialController
    {
        private readonly string conexion =
            "Server=localhost;Database=batallaanimedb;Uid=root;Pwd=123456789;";
        public void GuardarHistorial(int idPersonaje, int victorias, int derrotas)
        {
            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=batallaanimedb;uid=root;pwd=123456789;"))
            {
                conn.Open();

                string query = @"
INSERT INTO historial_personajes (Id_personaje, Victorias, Derrotas)
VALUES (@id, @v, @d)
ON DUPLICATE KEY UPDATE
    Victorias = Victorias + @v,
    Derrotas = Derrotas + @d";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", idPersonaje);
                cmd.Parameters.AddWithValue("@v", victorias);
                cmd.Parameters.AddWithValue("@d", derrotas);

                cmd.ExecuteNonQuery();
            }
        }
        internal List<HistorialDTO> ObtenerHistorial()
        {
            List<HistorialDTO> lista = new List<HistorialDTO>();

            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=batallaanimedb;uid=root;pwd=123456789;"))
            {
                conn.Open();

                string query = @"
SELECT 
    h.Id_historial,
    h.Id_personaje,
    p.Nombre AS Personaje,
    h.Victorias,
    h.Derrotas,
    (h.Victorias * 100.0 / (h.Victorias + h.Derrotas)) AS WinRate
FROM historial_personajes h
INNER JOIN personajes p 
    ON h.Id_personaje = p.Id_personaje";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new HistorialDTO
                        {
                            IdHistorial = Convert.ToInt32(reader["Id_historial"]),
                            IdPersonaje = Convert.ToInt32(reader["Id_personaje"]),
                            Personaje = reader["Personaje"].ToString(),
                            Victorias = Convert.ToInt32(reader["Victorias"]),
                            Derrotas = Convert.ToInt32(reader["Derrotas"]),
                            WinRate = Convert.ToDouble(reader["WinRate"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}