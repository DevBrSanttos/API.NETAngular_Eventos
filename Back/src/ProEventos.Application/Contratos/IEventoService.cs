using System.Threading.Tasks;
using ProEventos.Application.Dtos;
namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> addEvento(int userId, EventoDto model);
        Task<EventoDto> updateEvento(int userId, int eventoId, EventoDto model);
        Task<bool> deleteEvento(int userId, int eventoId);
        Task<EventoDto[]> getAllEventosAsync(int userId, bool includePalestrantes = false);
        Task<EventoDto[]> getAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false);
        Task<EventoDto> getEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);
    }
}