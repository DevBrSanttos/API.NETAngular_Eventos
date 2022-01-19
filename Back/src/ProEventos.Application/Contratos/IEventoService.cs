using System.Threading.Tasks;
using ProEventos.Application.Dtos;
namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> addEvento(EventoDto model);
        Task<EventoDto> updateEvento(int eventoId, EventoDto model);
        Task<bool> deleteEvento(int eventoId);
        Task<EventoDto[]> getAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDto[]> getAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto> getEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}