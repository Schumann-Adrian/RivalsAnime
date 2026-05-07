using System;

namespace RivalsAnime.Model
{
    public class PersonajeDTO
    {
        public string Nombre { get; set; } = "";
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public string Habilidad { get; set; } = "";
    }
}