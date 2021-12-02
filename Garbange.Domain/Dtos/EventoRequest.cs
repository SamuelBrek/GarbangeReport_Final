using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos
{
    public record EventoRequest(string nombreEvento, string fechaEvento, 
    string horaEvento, int personasEvento, string ubicacionEvento, 
    string descripcionEvento, string imagenEvento);
}