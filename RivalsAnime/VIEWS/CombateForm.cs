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
    public partial class CombateForm : Form
    {
        List<PersonajeDTO> equipoJugador;
        List<PersonajeDTO> equipoCPU;
        public CombateForm(
        List<PersonajeDTO> jugador,
        List<PersonajeDTO> cpu)
        {
            InitializeComponent();

            equipoJugador = jugador;
            equipoCPU = cpu;
        }
    }
}
