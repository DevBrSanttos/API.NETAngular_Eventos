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


        public async Task<Palestrante[]> getAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking().OrderBy(p => p.id);
            return await query.ToArrayAsync();

        }

        public async Task<Palestrante[]> getAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking()
                         .OrderBy(p => p.id)
                         .Where(p => p.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> getPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = queryDefault(includeEventos);

            query = query.AsNoTracking()
                         .Where(p => p.id == palestranteId);
            return await query.FirstOrDefaultAsync();

        }

        private IQueryable<Palestrante> queryDefault(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                   .Include(p => p.redesSoiais);

            if (includeEventos)
                query = query
                    .Include(p => p.palestrantesEventos)
                    .ThenInclude(pe => pe.evento);
            return query;
        }
    }
}