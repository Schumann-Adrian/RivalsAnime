using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class CombateForm : BaseForm
    {
        List<PersonajeDTO> equipoJugador;
        List<PersonajeDTO> equipoCPU;

        PersonajeDTO jugadorActual;
        PersonajeDTO cpuActual;

        int vidaJugador;
        int vidaCPU;

        Random rnd = new Random();

        public CombateForm(
            List<PersonajeDTO> jugador,
            List<PersonajeDTO> cpu)
        {
            InitializeComponent();

            equipoJugador = jugador;
            equipoCPU = cpu;

            this.Load += CombateForm_Load;
        }

        private void CombateForm_Load(object sender, EventArgs e)
        {
            // primer personaje de cada equipo
            jugadorActual = equipoJugador[0];
            cpuActual = equipoCPU[0];

            // vidas iniciales
            vidaJugador = jugadorActual.Vida;
            vidaCPU = cpuActual.Vida;

            // cargar gifs
            CargarGif(picJugador1, jugadorActual.Nombre, true);
            CargarGif(picCPU1, cpuActual.Nombre, false);


            // barras vida
            progressJugador.Maximum = jugadorActual.Vida;
            progressJugador.Value = vidaJugador;

            progressCPU.Maximum = cpuActual.Vida;
            progressCPU.Value = vidaCPU;

            ActualizarUI();
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

        private void ActualizarUI()
        {
            if (vidaJugador < 0)
                vidaJugador = 0;

            if (vidaCPU < 0)
                vidaCPU = 0;

            progressJugador.Value = vidaJugador;
            progressCPU.Value = vidaCPU;
        }

        // TURNO CPU
        private void TurnoCPU()
        {
            if (vidaCPU <= 0)
                return;

            int daño = rnd.Next(
                cpuActual.Ataque / 8,
                cpuActual.Ataque / 5
            );

            daño -= jugadorActual.Defensa / 10;

            if (daño < 5)
                daño = 5;

            vidaJugador -= daño;

            MessageBox.Show(
                cpuActual.Nombre +
                " atacó e hizo " +
                daño + " de daño"
            );

            ActualizarUI();

            VerificarKO();
        }

        // VERIFICAR MUERTE
        private void VerificarKO()
        {
            // muere cpu
            if (vidaCPU <= 0)
            {
                MessageBox.Show(
                    cpuActual.Nombre +
                    " fue derrotado"
                );
            }

            // muere jugador
            if (vidaJugador <= 0)
            {
                MessageBox.Show(
                    jugadorActual.Nombre +
                    " fue derrotado"
                );
            }
        }

        private void btnAtaque_Click_1(object sender, EventArgs e)
        {
            int daño = rnd.Next(
               jugadorActual.Ataque / 8,
               jugadorActual.Ataque / 5
           );

            daño -= cpuActual.Defensa / 10;

            if (daño < 5)
                daño = 5;

            vidaCPU -= daño;

            MessageBox.Show(
                jugadorActual.Nombre +
                " hizo " + daño + " de daño"
            );

            ActualizarUI();

            VerificarKO();

            TurnoCPU();
        }

        private void btnHabilidad_Click_1(object sender, EventArgs e)
        {
            int probabilidadFallo;
            int daño;

            // personajes débiles = más precisión
            if (jugadorActual.Ataque < 100)
            {
                probabilidadFallo = 15;

                daño = rnd.Next(
                    jugadorActual.Ataque / 4,
                    jugadorActual.Ataque / 3
                );
            }
            else
            {
                // personajes fuertes = más riesgo
                probabilidadFallo = 35;

                daño = rnd.Next(
                    jugadorActual.Ataque / 2,
                    jugadorActual.Ataque
                );
            }

            int tirada = rnd.Next(1, 101);

            // falló
            if (tirada <= probabilidadFallo)
            {
                MessageBox.Show("La habilidad falló ❌");

                TurnoCPU();

                return;
            }

            daño -= cpuActual.Defensa / 8;

            if (daño < 10)
                daño = 10;

            vidaCPU -= daño;

            MessageBox.Show(
                jugadorActual.Habilidad +
                " hizo " + daño + " de daño"
            );

            ActualizarUI();

            VerificarKO();

            TurnoCPU();
        }
    }
}