using RivalsAnime.Controller;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class BatallaForm : BaseForm
    {
        List<PersonajeDTO> equipoJugador = new List<PersonajeDTO>();
        List<PersonajeDTO> equipoCPU = new List<PersonajeDTO>();

        public BatallaForm()
        {
            InitializeComponent();

            stats1.BackColor = Color.FromArgb(30, 30, 30);
            stats1.ForeColor = Color.White;
            stats1.BorderStyle = BorderStyle.None;
            stats1.Font = new Font("Consolas", 12, FontStyle.Bold);
            stats1.ItemHeight = 20;
            stats2.BackColor = Color.FromArgb(30, 30, 30);
            stats2.ForeColor = Color.White;
            stats2.BorderStyle = BorderStyle.None;
            stats2.Font = new Font("Consolas", 12, FontStyle.Bold);
            stats2.ItemHeight = 20;
        }

        private void SeleccionarPersonaje(string nombre)
        {
            PersonajeController controller = new PersonajeController();

            var lista = controller.ObtenerPersonajes();

            var p = lista.FirstOrDefault(x => x.Nombre == nombre);

            if (p == null) return;

            // evitar repetidos
            if (equipoJugador.Any(x => x.Nombre == p.Nombre))
            {
                return;
            }

            // si ya hay 2 personajes
            // elimina el primero automáticamente
            if (equipoJugador.Count >= 2)
            {
                equipoJugador.RemoveAt(0);
            }

            // añadir nuevo personaje
            equipoJugador.Add(p);

            // refrescar selección
            MostrarSeleccionJugador();
        }

        private void MostrarSeleccionJugador()
        {
            // SLOT 1
            if (equipoJugador.Count >= 1)
            {
                CargarGif(picseleccion1, equipoJugador[0].Nombre, true);
                CargarStats(stats1, equipoJugador[0]);
            }
            else
            {
                picseleccion1.Image = null;
                stats1.Items.Clear();
            }

            // SLOT 2
            if (equipoJugador.Count >= 2)
            {
                CargarGif(picseleccion2, equipoJugador[1].Nombre, true);
                CargarStats(stats2, equipoJugador[1]);
            }
            else
            {
                picseleccion2.Image = null;
                stats2.Items.Clear();
            }
        }

        private void CargarGif(PictureBox pic, string nombre, bool derecha)
        {
            string lado = derecha ? "derecha" : "izquierda";

            string ruta = Path.Combine(
                Application.StartupPath,
                "Resources",
                "GIFS proyecto",
                nombre + lado + ".gif"
            );

            if (File.Exists(ruta))
            {
                pic.Image?.Dispose();

                pic.Image = Image.FromFile(ruta);

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.BackColor = Color.Transparent;
            }
            else
            {
                MessageBox.Show("GIF no encontrado: " + ruta);
            }
        }

        private void GenerarEquipoCPU()
        {
            PersonajeController controller = new PersonajeController();

            var lista = controller.ObtenerPersonajes();

            Random rnd = new Random();

            equipoCPU.Clear();

            while (equipoCPU.Count < 2)
            {
                var random = lista[rnd.Next(lista.Count)];

                bool repetido =
                    equipoJugador.Any(x => x.Nombre == random.Nombre) ||
                    equipoCPU.Any(x => x.Nombre == random.Nombre);

                if (!repetido)
                {
                    equipoCPU.Add(random);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (equipoJugador.Count < 2)
            {
                MessageBox.Show("Selecciona 2 personajes");
                return;
            }

            GenerarEquipoCPU();

            CombateForm combate = new CombateForm(
                equipoJugador,
                equipoCPU
            );

            combate.Show();

            this.Hide();
        }
        private void CargarStats(ListBox stats, PersonajeDTO p)
        {
            stats.Items.Clear();

            stats.Items.Add("👤 " + p.Nombre);
            stats.Items.Add("❤️ Vida: " + p.Vida);
            stats.Items.Add("⚔️ Ataque: " + p.Ataque);
            stats.Items.Add("🛡️ Defensa: " + p.Defensa);
            stats.Items.Add("✨ " + p.Habilidad);
        }
        private void Goku_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Goku");
        }

        private void Naruto_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Naruto");
        }

        private void Edward_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Edward Elrick");
        }

        private void Vegetta_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Vegetta");
        }

        private void Luffy_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Luffy");
        }

        private void Freezer_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Freezer");
        }

        private void Ichigo_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Ichigo");
        }

        private void Saitama_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Saitama");
        }

        private void Zoro_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Zoro");
        }
    }
}