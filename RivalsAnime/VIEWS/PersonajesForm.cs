using System.IO;
using RivalsAnime.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class PersonajesForm : BaseForm
    {
        PictureBox seleccionado = null;
        bool encendido = false;

        // 🔥 NUEVO
        Dictionary<PictureBox, Size> tamañosOriginales = new Dictionary<PictureBox, Size>();
        List<PictureBox> personajes = new List<PictureBox>();

        public PersonajesForm()
        {
            InitializeComponent();

            

            lisStats.BackColor = Color.FromArgb(30, 30, 30);
            lisStats.ForeColor = Color.White;
            lisStats.BorderStyle = BorderStyle.None;
            lisStats.Font = new Font("Consolas", 12, FontStyle.Bold);
            lisStats.ItemHeight = 20;

            picPersonajeGrande.Location = new Point(100, 30);
            picPersonajeGrande.Size = new Size(400, 350);
            picPersonajeGrande.SizeMode = PictureBoxSizeMode.Zoom;

            // 🔥 LISTA DE PERSONAJES
            personajes.AddRange(new PictureBox[]
            {
                Goku, Naruto, Edward, Vegetta, Luffy, Freezer, Ichigo, Saitama, Zoro
            });

            // 🔥 GUARDAR TAMAÑOS ORIGINALES
            foreach (var p in personajes)
            {
                tamañosOriginales[p] = p.Size;
            }
        }

        private void CargarPersonaje(string nombre)
        {
            PersonajeController controller = new PersonajeController();

            var lista = controller.ObtenerPersonajes();
            var p = lista.FirstOrDefault(x => x.Nombre == nombre);

            if (p == null) return;

            string ruta = Path.Combine(Application.StartupPath, "Imagenes", p.Nombre + ".png");

            if (File.Exists(ruta))
            {
                picPersonajeGrande.Image?.Dispose();

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

            lisStats.Items.Clear();
            lisStats.Items.Add("👤 " + p.Nombre);
            lisStats.Items.Add("❤️ Vida: " + p.Vida);
            lisStats.Items.Add("⚔️ Ataque: " + p.Ataque);
            lisStats.Items.Add("🛡️ Defensa: " + p.Defensa);
            lisStats.Items.Add("✨ " + p.Habilidad);
        }

        private void SeleccionarMarco(PictureBox pic)
        {
            // 🔄 resetear todos
            foreach (var p in personajes)
            {
                p.Size = tamañosOriginales[p];
                p.BackColor = Color.Transparent;
            }

            // ⭐ agrandar seleccionado
            float escala = 1.2f; // 20% más grande

            pic.Size = new Size(
                (int)(tamañosOriginales[pic].Width * escala),
                (int)(tamañosOriginales[pic].Height * escala)
            );

            seleccionado = pic;
        }

        private void Goku_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Goku);
            CargarPersonaje("Goku");
        }

        private void Naruto_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Naruto);
            CargarPersonaje("Naruto");
        }

        private void Edward_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Edward);
            CargarPersonaje("Edward Elrick");
        }

        private void Vegetta_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Vegetta);
            CargarPersonaje("Vegetta");
        }

        private void Luffy_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Luffy);
            CargarPersonaje("Luffy");
        }

        private void Freezer_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Freezer);
            CargarPersonaje("Freezer");
        }

        private void Ichigo_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Ichigo);
            CargarPersonaje("Ichigo");
        }

        private void Saitama_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Saitama);
            CargarPersonaje("Saitama");
        }

        private void Zoro_Click(object sender, EventArgs e)
        {
            SeleccionarMarco(Zoro);
            CargarPersonaje("Zoro");
        }

    }
}