using MySql.Data.MySqlClient;
using RivalsAnime.Controller;
using RivalsAnime.Database;
using RivalsAnime.Model;
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

        HistorialController controller =
             new HistorialController();

        public HistorialForm()
        {
            InitializeComponent();
        }

        private void CargarHistorial()
        {
            try
            {
                List<HistorialDTO> lista =
                    controller.ObtenerHistorial();

                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = lista;

                // OCULTAR COLUMNAS
                dgvHistorial.Columns["IdHistorial"].Visible = false;
                dgvHistorial.Columns["IdPersonaje"].Visible = false;

                // CAMBIAR TITULOS
                dgvHistorial.Columns["Personaje"].HeaderText =
                    "Personaje";

                dgvHistorial.Columns["Victorias"].HeaderText =
                    "Victorias";

                dgvHistorial.Columns["Derrotas"].HeaderText =
                    "Derrotas";

                dgvHistorial.Columns["WinRate"].HeaderText =
                    "Win Rate %";

                // FORMATO %
                dgvHistorial.Columns["WinRate"]
                    .DefaultCellStyle.Format = "0.00'%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void HistorialForm_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm user = new UserForm();
            user.Show();
        }
    }
}
