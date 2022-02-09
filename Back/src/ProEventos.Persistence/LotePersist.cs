using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class LotePersist : ILotePersist
    {
        public readonly ProEventosContext _context;

        public LotePersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Lote> getLoteByIdsAsync(int eventoId, int loteId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking()
                         .Where(lote => lote.eventoId == eventoId
                                     && lote.id == loteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Lote[]> getLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking()
                         .Where(lote => lote.eventoId == eventoId);

            return await query.ToArrayAsync();

        }
    }
}