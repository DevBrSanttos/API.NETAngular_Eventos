using System.Collections.Generic;

namespace ProEventos.Application.Dtos
{
    public class PalestranteDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string miniCurriculo { get; set; }
        public string imagemURL { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public IEnumerable<RedeSocialDto> redesSoiais { get; set; }
        public IEnumerable<PalestranteDto> palestrantes { get; set; }
    }
}