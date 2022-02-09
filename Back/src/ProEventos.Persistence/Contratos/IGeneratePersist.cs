using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeneratePersist
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRage<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}