using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        Task<Evento[]> getAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> getAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}