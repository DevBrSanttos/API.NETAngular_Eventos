using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface ILotePersist
    {
        Task<Lote[]> getLotesByEventoIdAsync(int eventoId);
        Task<Lote> getLoteByIdsAsync(int eventoId, int loteId);
    }
}