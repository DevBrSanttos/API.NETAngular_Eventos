using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> addEvento(Evento model);
        Task<Evento> updateEvento(int eventoId, Evento model);
        Task<bool> deleteEvento(int eventoId);
        Task<Evento[]> getAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> getAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}