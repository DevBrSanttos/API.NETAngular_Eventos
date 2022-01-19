
namespace ProEventos.Application.Dtos
{
    public class RedeSocialDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string URL { get; set; }
        public int? eventoId { get; set; }
        public EventoDto evento { get; set; }
        public int? palestranteId { get; set; }
        public PalestranteDto palestrante { get; set; }
    }
}