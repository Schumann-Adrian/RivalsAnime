using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class UserForm : BaseForm
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            this.Close();
            HistorialForm historial = new HistorialForm();
            historial.Show();
        }

        private void btnpersonajes_Click(object sender, EventArgs e)
        {
            this.Close();
            PersonajesForm personaje = new PersonajesForm();
            personaje.Show();
        }
    }
}
