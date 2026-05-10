using System.IO;
using RivalsAnime.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class PersonajesForm : BaseForm
    {
        public PersonajesForm()
        {
            InitializeComponent();

            lisStats.BackColor = Color.FromArgb(30, 30, 30);
            lisStats.ForeColor = Color.White;
            lisStats.BorderStyle = BorderStyle.None;
            lisStats.Font = new Font("Consolas", 12, FontStyle.Bold);
            lisStats.ItemHeight = 20;

            picPersonajeGrande.Location = new Point(250, 80);
            picPersonajeGrande.Size = new Size(350, 300);
            picPersonajeGrande.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void CargarPersonaje(string nombre)
        {
            PersonajeController controller = new PersonajeController();

            var lista = controller.ObtenerPersonajes();
            var p = lista.FirstOrDefault(x => x.Nombre == nombre);

            if (p == null) return;

            // IMAGEN
            string ruta = Path.Combine(Application.StartupPath, "Imagenes", p.Nombre + ".png");


            if (File.Exists(ruta))
            {
                picPersonajeGrande.Image?.Dispose(); // 🔥 limpia la anterior

                using (var bmpTemp = new Bitmap(ruta))
                {
                    picPersonajeGrande.Image = new Bitmap(bmpTemp);
                }
                picPersonajeGrande.BringToFront();
            }
            else
            {
                MessageBox.Show("Imagen no encontrada: " + ruta);
            }

            // STATS (ListBox por ejemplo)
            lisStats.Items.Clear();
            lisStats.Items.Add("👤 " + p.Nombre);
            lisStats.Items.Add("❤️ Vida: " + p.Vida);
            lisStats.Items.Add("⚔️ Ataque: " + p.Ataque);
            lisStats.Items.Add("🛡️ Defensa: " + p.Defensa);
            lisStats.Items.Add("✨ " + p.Habilidad);
        }

        private void Goku_Click(object sender, EventArgs e)
        {
            CargarPersonaje("Goku");
        }
    }
}
