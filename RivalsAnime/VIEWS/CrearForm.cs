using RivalsAnime.Controller;
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
    public partial class CrearForm : Form
    {
        public CrearForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtVida.Text) ||
        string.IsNullOrWhiteSpace(txtVida.Text) ||
        string.IsNullOrWhiteSpace(txtDefensa.Text))
            {
                MessageBox.Show("Completa todos los campos ❌");
                return;
            }

            PersonajeDTO p = new PersonajeDTO()
            {
                Nombre = txtNombre.Text,
                Vida = int.Parse(txtVida.Text),
                Ataque = int.Parse(txtVida.Text),
                Defensa = int.Parse(txtDefensa.Text),
                Habilidad = txtHabilidad.Text
            };

            PersonajeController controller = new PersonajeController();

            bool resultado = controller.CrearPersonaje(p);

            if (resultado)
            {
                MessageBox.Show("Personaje creado 🔥");

                // limpiar campos
                txtNombre.Clear();
                txtVida.Clear();
                txtVida.Clear();
                txtDefensa.Clear();
                txtHabilidad.Clear();
            }
            else
            {
                MessageBox.Show("Error al crear ❌");
            }
        }
    }
}
