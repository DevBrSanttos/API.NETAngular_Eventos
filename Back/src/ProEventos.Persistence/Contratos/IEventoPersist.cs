using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        Task<Evento[]> getAllEventosAsync(int userId, bool includePalestrantes = false);
        Task<Evento[]> getAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false);
        Task<Evento> getEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);
    }
}