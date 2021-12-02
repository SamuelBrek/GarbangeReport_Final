using System;
using System.Collections.Generic;

#nullable disable

namespace Garbange.Domain.Entities
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public string FechaEvento { get; set; }
        public string HoraEvento { get; set; }
        public int PersonasEvento { get; set; }
        public string UbicacionEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public string ImagenEvento { get; set; }
    }
}
