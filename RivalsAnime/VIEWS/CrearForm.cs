using RivalsAnime.Controller;
using RivalsAnime.Model;
using System;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class CrearForm : BaseForm
    {
        private AdminForm adminForm;

        public CrearForm(AdminForm admin)
        {
            InitializeComponent();
            adminForm = admin;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 🔴 Validación básica
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtVida.Text) ||
                string.IsNullOrWhiteSpace(txtAtaque.Text) ||
                string.IsNullOrWhiteSpace(txtDefensa.Text))
            {
                MessageBox.Show("Completa todos los campos ❌");
                return;
            }

            // 🔴 Validar números
            if (!int.TryParse(txtVida.Text, out int vida) ||
                !int.TryParse(txtAtaque.Text, out int ataque) ||
                !int.TryParse(txtDefensa.Text, out int defensa))
            {
                MessageBox.Show("Vida, Ataque y Defensa deben ser números ❌");
                return;
            }

            // 🟢 Crear objeto
            PersonajeDTO p = new PersonajeDTO()
            {
                Nombre = txtNombre.Text,
                Vida = vida,
                Ataque = ataque,
                Defensa = defensa,
                Habilidad = txtHabilidad.Text
            };

            // 🟢 Insertar en BD
            PersonajeController controller = new PersonajeController();
            bool resultado = controller.CrearPersonaje(p);

            if (resultado)
            {
                MessageBox.Show("Personaje creado 🔥");

                // 🔥 ACTUALIZAR ADMIN
                adminForm.CargarPersonajes();

                adminForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear ❌");
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminForm adminForm = new AdminForm(); 
            adminForm.Show();
        }
    }
}