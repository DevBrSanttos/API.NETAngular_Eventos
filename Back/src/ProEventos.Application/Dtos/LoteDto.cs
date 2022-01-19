
namespace ProEventos.Application.Dtos
{
    public class LoteDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public int quantidade { get; set; }
        public int eventoId { get; set; }
        public EventoDto evento { get; set; }
    }
}