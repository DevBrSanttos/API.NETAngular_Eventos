using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeneratePersist
    {
        //GERAL
        void add<T>(T entity) where T : class;
        void update<T>(T entity) where T : class;
        void delete<T>(T entity) where T : class;
        void deleteRage<T>(T[] entity) where T : class;
        Task<bool> saveChangesAsync();
    }
}