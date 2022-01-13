using System;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public DateTime? dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
        public int quantidade { get; set; }
        public int eventoId { get; set; }
        public Evento evento { get; set; }
    }
}