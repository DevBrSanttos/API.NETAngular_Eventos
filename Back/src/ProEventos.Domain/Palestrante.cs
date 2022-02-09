using System;
using System.Collections.Generic;
using ProEventos.Domain.Identity;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int id { get; set; }
        public string miniCurriculo { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public IEnumerable<RedeSocial> redesSoiais { get; set; }
        public IEnumerable<PalestranteEvento> palestrantesEventos { get; set; }

    }
}