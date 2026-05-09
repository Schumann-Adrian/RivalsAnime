using MySql.Data.MySqlClient;
using RivalsAnime.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class HistorialForm : BaseForm
    {

        MySqlConnection con;
        public HistorialForm()
        {
            InitializeComponent();
        }
        private void HistorialForm_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            string query = @"SELECT 
                        u.nombre AS Usuario,
                        p.nombre AS Personaje,
                        h.victorias,
                        h.derrotas,
                        h.winrate
                        FROM historial h
                        JOIN usuario u ON h.id_persona = u.id_persona
                        JOIN personajes p ON h.id_personaje = p.id_personaje
                        ORDER BY p.nombre, h.winrate DESC";

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            datagridHistorial.DataSource = dt;

            // Estética
            datagridHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridHistorial.ReadOnly = true;
        }
    }
}
