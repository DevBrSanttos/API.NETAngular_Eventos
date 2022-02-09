using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using ProEventos.Application.Contratos;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        public readonly ILoteService _loteService;

        public LotesController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        // GET api/lotes/?
        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _loteService.getLotesByEventoIdAsync(eventoId);
                if (lotes == null)
                    return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar lotes. Erro: {ex.Message}");
            }

        }

        // PUT api/lotes/?
        [HttpPut("{eventoId}")]
        public async Task<IActionResult> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _loteService.saveLotes(eventoId, models);
                if (lotes == null)
                    return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar lotes. Erro: {ex.Message}");
            }

        }

        // DELETE api/lotes/?/?
        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.getLotebyIdsAsync(eventoId, loteId);
                if (lote == null)
                    return NoContent();

                return await _loteService.deleteLote(lote.eventoId, lote.id)
                        ? Ok("Lote deletado")
                        : throw new Exception("Ocorreu um problema não específico ao tentar deletar.");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar lotes. Erro: {ex.Message}");
            }
        }
    }
}
