using System.Threading.Tasks;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Contratos
{
    public interface ILoteService
    {
        Task<LoteDto[]> saveLotes(int eventoId, LoteDto[] lotes);
        Task<bool> deleteLote(int eventoId, int loteId);
        Task<LoteDto[]> getLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> getLotebyIdsAsync(int eventoId, int loteId);
    }
}