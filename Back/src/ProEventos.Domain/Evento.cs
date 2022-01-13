using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int id { get; set; }
        public string imagemURL { get; set; }
        public string local { get; set; }
        public DateTime? dataEvento { get; set; }
        public string tema { get; set; }
        public int qtdPessoas { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public IEnumerable<Lote> lotes { get; set; }
        public IEnumerable<RedeSocial> redesSociais { get; set; }
        public IEnumerable<PalestranteEvento> palestrantesEventos { get; set; }

    }
}