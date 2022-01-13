using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        public readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> getAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = queryDefault(includePalestrantes);

            query = query.AsNoTracking().OrderBy(e => e.id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> getAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = queryDefault(includePalestrantes);

            query = query.AsNoTracking().OrderBy(e => e.id)
                         .Where(e => e.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = queryDefault(includePalestrantes);

            query = query.AsNoTracking().Where(e => e.id == eventoId);

            return await query.FirstOrDefaultAsync();
        }


        private IQueryable<Evento> queryDefault(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.lotes)
                .Include(e => e.redesSociais);

            if (includePalestrantes)
                query = query
                    .Include(e => e.palestrantesEventos)
                    .ThenInclude(pe => pe.palestrante);

            return query;
        }
    }
}