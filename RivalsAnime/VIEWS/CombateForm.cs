using RivalsAnime.Controller;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class CombateForm : BaseForm
    {
        List<PersonajeDTO> equipoJugador;
        List<PersonajeDTO> equipoCPU;

        int indiceJugador = 0;
        int indiceCPU = 0;

        PersonajeDTO jugadorActual;
        PersonajeDTO cpuActual;

        int vidaJugador;
        int vidaCPU;

        bool combateTerminado = false;
        bool turnoEnProceso = false;

        bool ganoJugador = false;
        bool resultadoGuardado = false;

        Random rnd = new Random();

        HistorialController controller = new HistorialController();

        public CombateForm(List<PersonajeDTO> jugador, List<PersonajeDTO> cpu)
        {
            InitializeComponent();

            equipoJugador = jugador;
            equipoCPU = cpu;

            panelNarracion.BackColor =
                Color.FromArgb(180, 0, 0, 0);

            this.Load += CombateForm_Load;

            btnsalir.Enabled = false;
        }

        private void CombateForm_Load(object sender, EventArgs e)
        {
            jugadorActual = equipoJugador[0];
            cpuActual = equipoCPU[0];

            vidaJugador = jugadorActual.Vida;
            vidaCPU = cpuActual.Vida;

            progressJugador.Maximum = jugadorActual.Vida;
            progressCPU.Maximum = cpuActual.Vida;

            CargarPersonajes();
            ActualizarUI();
        }

        private void CargarPersonajes()
        {
            CargarGif(picJugador1, jugadorActual.Nombre, true);
            CargarGif(picCPU1, cpuActual.Nombre, false);
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
        }

        private void ActualizarUI()
        {
            if (vidaJugador < 0) vidaJugador = 0;
            if (vidaCPU < 0) vidaCPU = 0;

            progressJugador.Value = vidaJugador;
            progressCPU.Value = vidaCPU;
        }

        private void BloquearBotones()
        {
            btnAtaque.Enabled = false;
            btnHabilidad.Enabled = false;
        }

        private void DesbloquearBotones()
        {
            if (!combateTerminado)
            {
                btnAtaque.Enabled = true;
                btnHabilidad.Enabled = true;
            }
        }

        private async Task MostrarMensaje(string mensaje)
        {
            panelNarracion.Visible = true;
            lblNarracion.Text = mensaje;
            await Task.Delay(1200);
        }

        private int CalcularAtaqueBasico(PersonajeDTO a, PersonajeDTO d)
        {
            int daño = rnd.Next(a.Ataque / 12, a.Ataque / 8);
            daño -= d.Defensa / 10;

            if (daño < 5) daño = 5;

            return daño;
        }

        private int CalcularHabilidad(PersonajeDTO a, PersonajeDTO d)
        {
            int daño;

            if (a.Ataque < 100)
                daño = rnd.Next(a.Ataque / 5, a.Ataque / 3);
            else
                daño = rnd.Next(a.Ataque / 4, a.Ataque / 2);

            daño -= d.Defensa / 8;

            if (daño < 10) daño = 10;

            return daño;
        }

        private async Task CambiarJugador()
        {
            indiceJugador++;

            if (indiceJugador >= equipoJugador.Count)
            {
                combateTerminado = true;
                ganoJugador = false;

                await MostrarMensaje("💀 Has perdido");

                btnsalir.Enabled = true;

                GuardarResultadoFinal();
                return;
            }

            jugadorActual = equipoJugador[indiceJugador];
            vidaJugador = jugadorActual.Vida;

            progressJugador.Maximum = jugadorActual.Vida;

            CargarGif(picJugador1, jugadorActual.Nombre, true);
            ActualizarUI();

            await MostrarMensaje("🔥 Entra " + jugadorActual.Nombre);
        }

        private async Task CambiarCPU()
        {
            indiceCPU++;

            if (indiceCPU >= equipoCPU.Count)
            {
                combateTerminado = true;
                ganoJugador = true;

                await MostrarMensaje("🏆 Has ganado");

                btnsalir.Enabled = true;

                GuardarResultadoFinal();
                return;
            }

            cpuActual = equipoCPU[indiceCPU];
            vidaCPU = cpuActual.Vida;

            progressCPU.Maximum = cpuActual.Vida;

            CargarGif(picCPU1, cpuActual.Nombre, false);
            ActualizarUI();

            await MostrarMensaje("🔥 Entra " + cpuActual.Nombre);
        }

        private async Task EjecutarTurno(bool usarHabilidad)
        {
            if (turnoEnProceso || combateTerminado)
                return;

            turnoEnProceso = true;
            BloquearBotones();

            int dañoJugador = 0;

            if (!usarHabilidad)
            {
                dañoJugador = CalcularAtaqueBasico(jugadorActual, cpuActual);
                vidaCPU -= dañoJugador;

                await MostrarMensaje(jugadorActual.Nombre + " atacó ⚔️");
                await MostrarMensaje(cpuActual.Nombre + " recibió " + dañoJugador);
            }
            else
            {
                int fallo = rnd.Next(1, 101);
                int prob = jugadorActual.Ataque < 100 ? 15 : 35;

                if (fallo > prob)
                {
                    dañoJugador = CalcularHabilidad(jugadorActual, cpuActual);
                    vidaCPU -= dañoJugador;

                    await MostrarMensaje(jugadorActual.Nombre + " usó " + jugadorActual.Habilidad);
                    await MostrarMensaje(cpuActual.Nombre + " recibió " + dañoJugador);
                }
                else
                {
                    await MostrarMensaje("❌ Falló la habilidad");
                }
            }

            ActualizarUI();

            if (vidaCPU <= 0)
            {
                await MostrarMensaje(cpuActual.Nombre + " derrotado 💀");
                await CambiarCPU();

                if (combateTerminado) return;
            }

            await Task.Delay(500);

            bool cpuSkill = rnd.Next(1, 101) <= 40;
            int dañoCPU = 0;

            if (!cpuSkill)
            {
                dañoCPU = CalcularAtaqueBasico(cpuActual, jugadorActual);
                vidaJugador -= dañoCPU;

                await MostrarMensaje(cpuActual.Nombre + " atacó ⚔️");
                await MostrarMensaje(jugadorActual.Nombre + " recibió " + dañoCPU);
            }
            else
            {
                int prob = cpuActual.Ataque < 100 ? 15 : 35;

                if (rnd.Next(1, 101) > prob)
                {
                    dañoCPU = CalcularHabilidad(cpuActual, jugadorActual);
                    vidaJugador -= dañoCPU;

                    await MostrarMensaje(cpuActual.Nombre + " usó habilidad");
                    await MostrarMensaje(jugadorActual.Nombre + " recibió " + dañoCPU);
                }
                else
                {
                    await MostrarMensaje("❌ CPU falló habilidad");
                }
            }

            ActualizarUI();

            if (vidaJugador <= 0)
            {
                await MostrarMensaje(jugadorActual.Nombre + " derrotado 💀");
                await CambiarJugador();

                if (combateTerminado) return;
            }

            panelNarracion.Visible = false;
            turnoEnProceso = false;
            DesbloquearBotones();
        }

        private void GuardarResultadoFinal()
        {
            if (resultadoGuardado)
                return;

            resultadoGuardado = true;

            foreach (var p in equipoJugador)
            {
                controller.GuardarHistorial(
                    p.IdPersonaje,
                    ganoJugador ? 1 : 0,
                    ganoJugador ? 0 : 1
                );
            }

            foreach (var p in equipoCPU)
            {
                controller.GuardarHistorial(
                    p.IdPersonaje,
                    !ganoJugador ? 1 : 0,
                    !ganoJugador ? 0 : 1
                );
            }
        }

        private async void btnAtaque_Click_1(object sender, EventArgs e)
        {
            await EjecutarTurno(false);
        }

        private async void btnHabilidad_Click_1(object sender, EventArgs e)
        {
            await EjecutarTurno(true);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            HistorialForm form = new HistorialForm();
            form.Show();
            this.Close();
        }
    }
}