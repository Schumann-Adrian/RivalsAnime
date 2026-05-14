using System;
using System.Collections.Generic;
using System.Text;

namespace RivalsAnime.Model
{
    internal class HistorialDTO
    {
        public int IdHistorial { get; set; }
        public int IdPersonaje { get; set; }
        public string Personaje { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
        public double WinRate { get; set; }
    }
}
