using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;
using Garbange.Infraestructure.Data;
using Garbange.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garbange.Infraestructure.Repositories
{
    public class EventoSQLrepositorie : IEventoRepository
    {
        private readonly Garbange4BContext _garbange;
        public EventoSQLrepositorie(Garbange4BContext garbange)
        {
            _garbange = garbange;
        }

        public async Task<IEnumerable<Evento>> AllDataEvento()
        {
            var evento = _garbange.Eventos.Select(evn => evn);
            return await evento.ToListAsync();
        }

        public async Task<Evento> GetById(int id)
        {
            var evento = await _garbange.Eventos.FirstOrDefaultAsync(dnc => dnc.IdEvento == id);
            return evento;
        }

        public async Task<IEnumerable<Evento>> GetByEvento(string nameEvento)
        {
            var evento = _garbange.Eventos.Where(evn => evn.NombreEvento == nameEvento);
            return await evento.ToListAsync();  
        }
        public async Task<int> Create(Evento evento)
        {
            var entity = evento;
            await _garbange.Eventos.AddAsync(entity);
            var rows = await _garbange.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("La información del evento no pudo ser completada...");

            return entity.IdEvento;
        }

        public async Task<bool> Update(int id, Evento evento)
        {
            if(id <= 0 || evento == null)
                throw new ArgumentException("Falta información para poder realizar la modificación...");

            var entity = await GetById(id);

            entity.NombreEvento = evento.NombreEvento;
            entity.FechaEvento = evento.FechaEvento;
            entity.HoraEvento = evento.HoraEvento;
            entity.PersonasEvento = evento.PersonasEvento;
            entity.UbicacionEvento = evento.UbicacionEvento;
            entity.DescripcionEvento = evento.DescripcionEvento;
            entity.ImagenEvento = evento.ImagenEvento;
            _garbange.Update(entity);
            var rows = await _garbange.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            if(id <= 0)
                throw new ArgumentException("No se encontró el registro proporcionado...");

            var entity = await GetById(id);
            _garbange.Remove(entity);
            var rows = await _garbange.SaveChangesAsync();
            return rows > 0;
        }

    }
}