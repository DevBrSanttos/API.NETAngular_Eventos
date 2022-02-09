using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Domain.Identity;

// Classe onde será feito as associações entre os DTOs e os Domains
namespace ProAgil.Application.Helpers
{
    public class ProEventoProfile : Profile
    {
        public ProEventoProfile()
        {
            // Mapear de domain para DTO ou o oposto
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

        }
    }
}