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
        // =====================================================
        // EQUIPOS
        // =====================================================

        List<PersonajeDTO> equipoJugador;
        List<PersonajeDTO> equipoCPU;

        int indiceJugador = 0;
        int indiceCPU = 0;

        PersonajeDTO jugadorActual;
        PersonajeDTO cpuActual;

        int vidaJugador;
        int vidaCPU;

        // =====================================================
        // CONTROL COMBATE
        // =====================================================

        bool combateTerminado = false;
        bool turnoEnProceso = false;

        Random rnd = new Random();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CombateForm(
            List<PersonajeDTO> jugador,
            List<PersonajeDTO> cpu)
        {
            InitializeComponent();

            equipoJugador = jugador;
            equipoCPU = cpu;

            panelNarracion.BackColor =
                Color.FromArgb(180, 0, 0, 0);

            this.Load += CombateForm_Load;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void CombateForm_Load(
            object sender,
            EventArgs e)
        {
            jugadorActual = equipoJugador[0];
            cpuActual = equipoCPU[0];

            vidaJugador = jugadorActual.Vida;
            vidaCPU = cpuActual.Vida;

            progressJugador.Maximum =
                jugadorActual.Vida;

            progressCPU.Maximum =
                cpuActual.Vida;

            CargarPersonajes();

            ActualizarUI();
        }

        // =====================================================
        // CARGAR PERSONAJES
        // =====================================================

        private void CargarPersonajes()
        {
            CargarGif(
                picJugador1,
                jugadorActual.Nombre,
                true);

            CargarGif(
                picCPU1,
                cpuActual.Nombre,
                false);
        }

        // =====================================================
        // GIFS
        // =====================================================

        private void CargarGif(
            PictureBox pic,
            string nombre,
            bool derecha)
        {
            string lado =
                derecha ? "derecha" : "izquierda";

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

                pic.SizeMode =
                    PictureBoxSizeMode.Zoom;

                pic.BackColor =
                    Color.Transparent;
            }
        }

        // =====================================================
        // UI
        // =====================================================

        private void ActualizarUI()
        {
            if (vidaJugador < 0)
                vidaJugador = 0;

            if (vidaCPU < 0)
                vidaCPU = 0;

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
            if (combateTerminado)
                return;

            btnAtaque.Enabled = true;
            btnHabilidad.Enabled = true;
        }

        // =====================================================
        // NARRACIÓN
        // =====================================================

        private async Task MostrarMensaje(
            string mensaje)
        {
            panelNarracion.Visible = true;

            lblNarracion.Text = mensaje;

            await Task.Delay(1300);
        }

        // =====================================================
        // DAÑO
        // =====================================================

        private int CalcularAtaqueBasico(
            PersonajeDTO atacante,
            PersonajeDTO defensor)
        {
            int daño = rnd.Next(
                atacante.Ataque / 12,
                atacante.Ataque / 8
            );

            daño -= defensor.Defensa / 10;

            if (daño < 5)
                daño = 5;

            return daño;
        }

        private int CalcularHabilidad(
            PersonajeDTO atacante,
            PersonajeDTO defensor)
        {
            int daño;

            if (atacante.Ataque < 100)
            {
                daño = rnd.Next(
                    atacante.Ataque / 5,
                    atacante.Ataque / 3
                );
            }
            else
            {
                daño = rnd.Next(
                    atacante.Ataque / 4,
                    atacante.Ataque / 2
                );
            }

            daño -= defensor.Defensa / 8;

            if (daño < 10)
                daño = 10;

            return daño;
        }

        // =====================================================
        // CAMBIO PERSONAJE
        // =====================================================

        private async Task CambiarJugador()
        {
            indiceJugador++;

            // perdió
            if (indiceJugador >= equipoJugador.Count)
            {
                combateTerminado = true;

                await MostrarMensaje(
                    "💀 Has perdido");

                return;
            }

            jugadorActual =
                equipoJugador[indiceJugador];

            vidaJugador =
                jugadorActual.Vida;

            progressJugador.Maximum =
                jugadorActual.Vida;

            CargarGif(
                picJugador1,
                jugadorActual.Nombre,
                true);

            ActualizarUI();

            await MostrarMensaje(
                "🔥 Entra " +
                jugadorActual.Nombre);
        }

        private async Task CambiarCPU()
        {
            indiceCPU++;

            // ganó
            if (indiceCPU >= equipoCPU.Count)
            {
                combateTerminado = true;

                await MostrarMensaje(
                    "🏆 Has ganado");

                return;
            }

            cpuActual =
                equipoCPU[indiceCPU];

            vidaCPU =
                cpuActual.Vida;

            progressCPU.Maximum =
                cpuActual.Vida;

            CargarGif(
                picCPU1,
                cpuActual.Nombre,
                false);

            ActualizarUI();

            await MostrarMensaje(
                "🔥 Entra " +
                cpuActual.Nombre);
        }

        // =====================================================
        // TURNO COMPLETO
        // =====================================================

        private async Task EjecutarTurno(
            bool usarHabilidad)
        {
            if (turnoEnProceso)
                return;

            if (combateTerminado)
                return;

            turnoEnProceso = true;

            BloquearBotones();

            // =================================================
            // TURNO JUGADOR
            // =================================================

            int dañoJugador = 0;

            if (!usarHabilidad)
            {
                dañoJugador =
                    CalcularAtaqueBasico(
                        jugadorActual,
                        cpuActual);

                vidaCPU -= dañoJugador;

                ActualizarUI();

                await MostrarMensaje(
                    jugadorActual.Nombre +
                    " atacó ⚔️");

                await MostrarMensaje(
                    cpuActual.Nombre +
                    " recibió " +
                    dañoJugador +
                    " de daño");
            }
            else
            {
                int fallo = rnd.Next(1, 101);

                int probabilidad =
                    jugadorActual.Ataque < 100
                    ? 15
                    : 35;

                if (fallo <= probabilidad)
                {
                    await MostrarMensaje(
                        jugadorActual.Nombre +
                        " usó " +
                        jugadorActual.Habilidad);

                    await MostrarMensaje(
                        "❌ La habilidad falló");
                }
                else
                {
                    dañoJugador =
                        CalcularHabilidad(
                            jugadorActual,
                            cpuActual);

                    vidaCPU -= dañoJugador;

                    ActualizarUI();

                    await MostrarMensaje(
                        jugadorActual.Nombre +
                        " usó " +
                        jugadorActual.Habilidad);

                    await MostrarMensaje(
                        cpuActual.Nombre +
                        " recibió " +
                        dañoJugador +
                        " de daño");
                }
            }

            // =================================================
            // CPU MUERTA
            // =================================================

            if (vidaCPU <= 0)
            {
                vidaCPU = 0;

                ActualizarUI();

                await MostrarMensaje(
                    cpuActual.Nombre +
                    " fue derrotado 💀");

                await CambiarCPU();

                if (combateTerminado)
                {
                    turnoEnProceso = false;
                    return;
                }
            }

            // =================================================
            // PEQUEÑA PAUSA
            // =================================================

            await Task.Delay(500);

            // =================================================
            // IA CPU
            // =================================================

            // 40% de usar habilidad
            bool cpuUsaHabilidad =
                rnd.Next(1, 101) <= 40;

            int dañoCPU = 0;

            // =================================================
            // ATAQUE BÁSICO CPU
            // =================================================

            if (!cpuUsaHabilidad)
            {
                dañoCPU =
                    CalcularAtaqueBasico(
                        cpuActual,
                        jugadorActual);

                vidaJugador -= dañoCPU;

                ActualizarUI();

                await MostrarMensaje(
                    cpuActual.Nombre +
                    " atacó ⚔️");

                await MostrarMensaje(
                    jugadorActual.Nombre +
                    " recibió " +
                    dañoCPU +
                    " de daño");
            }
            else
            {
                // =================================================
                // PROBABILIDAD DE FALLO CPU
                // =================================================

                int probabilidadFallo;

                // personajes débiles fallan menos
                if (cpuActual.Ataque < 100)
                {
                    probabilidadFallo = 15;
                }
                else
                {
                    // personajes fuertes arriesgan más
                    probabilidadFallo = 35;
                }

                int tirada = rnd.Next(1, 101);

                // =================================================
                // FALLÓ
                // =================================================

                if (tirada <= probabilidadFallo)
                {
                    await MostrarMensaje(
                        cpuActual.Nombre +
                        " usó " +
                        cpuActual.Habilidad);

                    await MostrarMensaje(
                        "❌ La habilidad falló");
                }
                else
                {
                    dañoCPU =
                        CalcularHabilidad(
                            cpuActual,
                            jugadorActual);

                    vidaJugador -= dañoCPU;

                    ActualizarUI();

                    await MostrarMensaje(
                        cpuActual.Nombre +
                        " usó " +
                        cpuActual.Habilidad);

                    await MostrarMensaje(
                        jugadorActual.Nombre +
                        " recibió " +
                        dañoCPU +
                        " de daño");
                }
            }

            // =================================================
            // JUGADOR MUERE
            // =================================================

            if (vidaJugador <= 0)
            {
                vidaJugador = 0;

                ActualizarUI();

                await MostrarMensaje(
                    jugadorActual.Nombre +
                    " fue derrotado 💀");

                await CambiarJugador();

                if (combateTerminado)
                {
                    turnoEnProceso = false;
                    return;
                }
            }

            // =================================================
            // FIN TURNO
            // =================================================

            panelNarracion.Visible = false;

            turnoEnProceso = false;

            DesbloquearBotones();
        }

        // =====================================================
        // BOTONES
        // =====================================================

        private async void btnAtaque_Click_1(
            object sender,
            EventArgs e)
        {
            await EjecutarTurno(false);
        }

        private async void btnHabilidad_Click_1(
            object sender,
            EventArgs e)
        {
            await EjecutarTurno(true);
        }
    }
}