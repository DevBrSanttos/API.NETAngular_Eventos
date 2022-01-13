using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string miniCurriculo { get; set; }
        public string imagemURL { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public IEnumerable<RedeSocial> redesSoiais { get; set; }
        public IEnumerable<PalestranteEvento> palestrantesEventos { get; set; }

    }
}