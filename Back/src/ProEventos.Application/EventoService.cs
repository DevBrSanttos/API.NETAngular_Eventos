using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeneratePersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;

        public EventoService(IGeneratePersist geralPersist, IEventoPersist eventoPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;
        }

        public async Task<EventoDto> addEvento(int userId, EventoDto model)
        {
            try
            {
                // Mapeando EventoDto para Evento
                var evento = _mapper.Map<Evento>(model);
                evento.userId = userId;

                _geralPersist.add<Evento>(evento);
                if (await _geralPersist.saveChangesAsync())
                {
                    var retorno = await _eventoPersist.getEventoByIdAsync(userId, evento.id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> updateEvento(int userId, int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.getEventoByIdAsync(userId, eventoId, false);
                if (evento == null)
                    return null;

                model.Id = evento.id;
                model.UserId = userId;

                _mapper.Map(model, evento);

                _geralPersist.update<Evento>(evento);

                if (await _geralPersist.saveChangesAsync())
                {
                    var retorno = await _eventoPersist.getEventoByIdAsync(userId, evento.id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> deleteEvento(int userId, int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.getEventoByIdAsync(userId, eventoId, false);
                if (evento == null)
                    throw new Exception("Evento não encontrado.");

                _geralPersist.delete<Evento>(evento);
                return await _geralPersist.saveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> getAllEventosAsync(int userId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.getAllEventosAsync(userId, includePalestrantes);
                if (eventos == null)
                    return null;

                // Mappeando os Eventos para EventoDto
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> getAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.getAllEventosByTemaAsync(userId, tema, includePalestrantes);
                if (eventos == null)
                    return null;

                // Mappeando os Eventos para EventoDto
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> getEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.getEventoByIdAsync(userId, eventoId, includePalestrantes);
                if (evento == null)
                    return null;

                // Mappeando o Evento para EventoDto
                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}