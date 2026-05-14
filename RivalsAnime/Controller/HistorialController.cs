using MySql.Data.MySqlClient;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;

namespace RivalsAnime.Controller
{
    internal class HistorialController
    {
        private readonly string conexion =
            "Server=localhost;Database=RivalsAnime;Uid=root;Pwd=;";

        public List<HistorialDTO> ObtenerHistorial()
        {
            List<HistorialDTO> lista =
                new List<HistorialDTO>();

            try
            {
                using (MySqlConnection cn =
                    new MySqlConnection(conexion))
                {
                    cn.Open();

                    string query = @"
                    SELECT 
                        h.id_historial,
                        p.nombre AS personaje,
                        h.victorias,
                        h.derrotas,
                        h.winrate
                    FROM historial h
                    INNER JOIN personajes p
                        ON h.id_personaje = p.id_personaje
                    ORDER BY h.victorias DESC;";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, cn))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HistorialDTO h =
                                    new HistorialDTO();

                                h.IdHistorial =
                                    Convert.ToInt32(
                                        reader["id_historial"]);

                                h.Personaje =
                                    reader["personaje"].ToString();

                                h.Victorias =
                                    Convert.ToInt32(
                                        reader["victorias"]);

                                h.Derrotas =
                                    Convert.ToInt32(
                                        reader["derrotas"]);

                                h.WinRate =
                                    Convert.ToDouble(
                                        reader["winrate"]);

                                lista.Add(h);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error cargando historial: "
                    + ex.Message);
            }

            return lista;
        }
    }
}