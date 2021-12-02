using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Responses
{
    public class EventoResponse
    {
        public int IdEvento { get; set; }
        public string InformacionEvento { get; set; }
        public string DatosEvento { get; set; }

    }
}