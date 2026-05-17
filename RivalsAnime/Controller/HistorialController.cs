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

        private void AsegurarColumnaJugador(MySqlConnection conn)
        {
            string comprobarColumna = @"
SELECT COUNT(*)
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = DATABASE()
  AND TABLE_NAME = 'historial_personajes'
  AND COLUMN_NAME = 'Es_jugador'";

            MySqlCommand comprobarCmd = new MySqlCommand(comprobarColumna, conn);
            int existe = Convert.ToInt32(comprobarCmd.ExecuteScalar());

            if (existe == 0)
            {
                string crearColumna = @"
ALTER TABLE historial_personajes
ADD COLUMN Es_jugador TINYINT(1) NOT NULL DEFAULT 0";

                MySqlCommand crearCmd = new MySqlCommand(crearColumna, conn);
                crearCmd.ExecuteNonQuery();
            }
        }

        private void ConsolidarHistorialPersonaje(MySqlConnection conn, int idPersonaje)
        {
            int idHistorial = 0;
            int totalVictorias = 0;
            int totalDerrotas = 0;

            string consultaTotales = @"
SELECT 
    MIN(Id_historial) AS Id_historial,
    COALESCE(SUM(Victorias), 0) AS Victorias,
    COALESCE(SUM(Derrotas), 0) AS Derrotas
FROM historial_personajes
WHERE Id_personaje = @id
  AND Es_jugador = 1";

            using (MySqlCommand cmd = new MySqlCommand(consultaTotales, conn))
            {
                cmd.Parameters.AddWithValue("@id", idPersonaje);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader["Id_historial"] != DBNull.Value)
                    {
                        idHistorial = Convert.ToInt32(reader["Id_historial"]);
                        totalVictorias = Convert.ToInt32(reader["Victorias"]);
                        totalDerrotas = Convert.ToInt32(reader["Derrotas"]);
                    }
                }
            }

            if (idHistorial == 0)
                return;

            string actualizarFilaPrincipal = @"
UPDATE historial_personajes
SET Victorias = @victorias,
    Derrotas = @derrotas,
    Es_jugador = 1
WHERE Id_historial = @idHistorial";

            using (MySqlCommand cmd = new MySqlCommand(actualizarFilaPrincipal, conn))
            {
                cmd.Parameters.AddWithValue("@victorias", totalVictorias);
                cmd.Parameters.AddWithValue("@derrotas", totalDerrotas);
                cmd.Parameters.AddWithValue("@idHistorial", idHistorial);
                cmd.ExecuteNonQuery();
            }

            string borrarDuplicados = @"
DELETE FROM historial_personajes
WHERE Id_personaje = @id
  AND Es_jugador = 1
  AND Id_historial <> @idHistorial";

            using (MySqlCommand cmd = new MySqlCommand(borrarDuplicados, conn))
            {
                cmd.Parameters.AddWithValue("@id", idPersonaje);
                cmd.Parameters.AddWithValue("@idHistorial", idHistorial);
                cmd.ExecuteNonQuery();
            }
        }

        public void GuardarHistorial(int idPersonaje, int victorias, int derrotas)
        {
            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=batallaanimedb;uid=root;pwd=123456789;"))
            {
                conn.Open();
                AsegurarColumnaJugador(conn);
                ConsolidarHistorialPersonaje(conn, idPersonaje);

                string query = @"
UPDATE historial_personajes
SET Victorias = Victorias + @v,
    Derrotas = Derrotas + @d,
    Es_jugador = 1
WHERE Id_personaje = @id
  AND Es_jugador = 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", idPersonaje);
                cmd.Parameters.AddWithValue("@v", victorias);
                cmd.Parameters.AddWithValue("@d", derrotas);

                int filasActualizadas = cmd.ExecuteNonQuery();

                if (filasActualizadas == 0)
                {
                    string insertar = @"
INSERT INTO historial_personajes (Id_personaje, Victorias, Derrotas, Es_jugador)
VALUES (@id, @v, @d, 1)";

                    using (MySqlCommand insertarCmd = new MySqlCommand(insertar, conn))
                    {
                        insertarCmd.Parameters.AddWithValue("@id", idPersonaje);
                        insertarCmd.Parameters.AddWithValue("@v", victorias);
                        insertarCmd.Parameters.AddWithValue("@d", derrotas);
                        insertarCmd.ExecuteNonQuery();
                    }
                }
            }
        }
        internal List<HistorialDTO> ObtenerHistorial()
        {
            List<HistorialDTO> lista = new List<HistorialDTO>();

            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=batallaanimedb;uid=root;pwd=123456789;"))
            {
                conn.Open();
                AsegurarColumnaJugador(conn);

                string query = @"
SELECT
    MIN(h.Id_historial) AS Id_historial,
    h.Id_personaje,
    p.Nombre AS Personaje,
    SUM(h.Victorias) AS Victorias,
    SUM(h.Derrotas) AS Derrotas,
    CASE
        WHEN SUM(h.Victorias) + SUM(h.Derrotas) = 0 THEN 0
        ELSE SUM(h.Victorias) * 100.0 / (SUM(h.Victorias) + SUM(h.Derrotas))
    END AS WinRate
FROM historial_personajes h
INNER JOIN personajes p 
    ON h.Id_personaje = p.Id_personaje
WHERE h.Es_jugador = 1
GROUP BY h.Id_personaje, p.Nombre";

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
