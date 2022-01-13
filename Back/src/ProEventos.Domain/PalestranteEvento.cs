namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int palestranteId { get; set; }
        public Palestrante palestrante { get; set; }
        public int eventoId { get; set; }
        public Evento evento { get; set; }
    }
}