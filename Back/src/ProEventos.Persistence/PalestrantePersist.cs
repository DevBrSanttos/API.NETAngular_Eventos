using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        public readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }


        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();

        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.User.primeiroNome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking()
                         .Where(p => p.Id == palestranteId);
            return await query.FirstOrDefaultAsync();

        }

        private IQueryable<Palestrante> queryDefault(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                   .Include(p => p.RedesSoiais);

            if (includeEventos)
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            return query;
        }
    }
}