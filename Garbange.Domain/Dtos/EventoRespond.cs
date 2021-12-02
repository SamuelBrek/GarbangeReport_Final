using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos
{
    public record EventoRespond(int idEvento, string nombreEvento,
    int personasEvento, string ubicacionEvento, string fechaEvento, 
    string descripcionEvento);
}