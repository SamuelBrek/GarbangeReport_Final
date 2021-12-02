using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;
using Garbange.Domain.Interfaces;

namespace Garbange.Application.Services
{
    public class EventoService : IEventoService
    {
        public bool ValidateCreate(Evento evento)
        {
            if(string.IsNullOrEmpty(evento.NombreEvento))
                return false;

            if(string.IsNullOrEmpty(evento.FechaEvento))
                return false;

            if(string.IsNullOrEmpty(evento.HoraEvento))
                return false;

            if((evento.PersonasEvento <= 0))
                return false;

            if(string.IsNullOrEmpty(evento.UbicacionEvento))
                return false;

            if(string.IsNullOrEmpty(evento.DescripcionEvento))
                return false;
            
            if(string.IsNullOrEmpty(evento.ImagenEvento))
                return false;

            return true;
        }

        public bool ValidateUpdate(Evento evento)
        {
            if(evento.IdEvento <= 0)
                return false;

            if(string.IsNullOrEmpty(evento.NombreEvento))
                return false;

            if(string.IsNullOrEmpty(evento.FechaEvento))
                return false;

            if(string.IsNullOrEmpty(evento.HoraEvento))
                return false;

            if((evento.PersonasEvento <= 0))
                return false;

            if(string.IsNullOrEmpty(evento.UbicacionEvento))
                return false;

            if(string.IsNullOrEmpty(evento.DescripcionEvento))
                return false;
            
            if(string.IsNullOrEmpty(evento.ImagenEvento))
                return false;

            return true;
        }
    }
}