using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeneratePersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeneratePersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> addEvento(Evento model)
        {
            try
            {
                _geralPersist.add(model);
                if (await _geralPersist.saveChangesAsync())
                    return await _eventoPersist.getEventoByIdAsync(model.id, false);

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> updateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = _eventoPersist.getEventoByIdAsync(eventoId, false);
                if (evento == null)
                    return null;

                model.id = evento.Id;
                _geralPersist.update(model);

                if (await _geralPersist.saveChangesAsync())
                    return await _eventoPersist.getEventoByIdAsync(model.id, false);

                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> deleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.getEventoByIdAsync(eventoId, false);
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

        public async Task<Evento[]> getAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.getAllEventosAsync(includePalestrantes);
                if (eventos == null)
                    return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> getAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.getAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null)
                    return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.getEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null)
                    return null;
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}