using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System.Linq;

namespace ProEventos.Application
{
    public class LoteService : ILoteService
    {
        private readonly IGeneratePersist _geralPersist;
        private readonly ILotePersist _lotePersist;
        private readonly IMapper _mapper;

        public LoteService(IGeneratePersist geralPersist, ILotePersist lotePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _lotePersist = lotePersist;
            _mapper = mapper;
        }

        public async Task<LoteDto[]> saveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _lotePersist.getLotesByEventoIdAsync(eventoId);
                if (lotes == null)
                    return null;

                foreach (var model in models)
                {
                    if (model.id == 0)
                        await addLote(eventoId, model);
                    else
                        await updateLote(eventoId, model, lotes);
                }

                var retorno = await _lotePersist.getLotesByEventoIdAsync(eventoId);
                return _mapper.Map<LoteDto[]>(retorno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> deleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.getLoteByIdsAsync(eventoId, loteId);
                if (lote == null)
                    throw new Exception("Lote não encontrado.");

                _geralPersist.delete<Lote>(lote);
                return await _geralPersist.saveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LoteDto[]> getLotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lotes = await _lotePersist.getLotesByEventoIdAsync(eventoId);
                if (lotes == null)
                    return null;

                // Mappeando os lotes para LoteDto
                var resultado = _mapper.Map<LoteDto[]>(lotes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto> getLotebyIdsAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.getLoteByIdsAsync(eventoId, loteId);
                if (lote == null)
                    return null;

                // Mappeando o lote para LoteDto
                var resultado = _mapper.Map<LoteDto>(lote);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task addLote(int eventoId, LoteDto model)
        {
            try
            {
                // Mapeando LoteDto para Lote
                var lote = _mapper.Map<Lote>(model);
                lote.eventoId = eventoId;

                _geralPersist.add<Lote>(lote);

                await _geralPersist.saveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task updateLote(int eventoId, LoteDto model, Lote[] lotes)
        {
            try
            {
                var lote = lotes.FirstOrDefault(lote => lote.id == model.id);
                model.eventoId = eventoId;

                _mapper.Map(model, lote);
                _geralPersist.update<Lote>(lote);
                await _geralPersist.saveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}