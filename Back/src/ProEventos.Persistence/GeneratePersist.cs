using System.Threading.Tasks;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeneratePersist : IGeneratePersist
    {
        private readonly ProEventosContext _context;

        public GeneratePersist(ProEventosContext context)
        {
            _context = context;
        }

        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void deleteRage<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> saveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


    }
}