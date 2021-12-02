using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Requests
{
    public class EventoUpdateRequest
    {
        public string NombreEvento { get; set; }
        public string FechaEvento { get; set; }
        public string HoraEvento { get; set; }
        public int PersonasEvento { get; set; }
        public string UbicacionEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public string ImagenEvento { get; set; }
    }
}