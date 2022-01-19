using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

// Classe onde será feito as associações entre os DTOs e os Domains
namespace ProAgil.Application.Helpers
{
    public class ProEventoProfile : Profile
    {
        public ProEventoProfile()
        {
            // Mapear de Evento para EventoDto ou o oposto
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

        }
    }
}