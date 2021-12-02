using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Responses
{
    public record DenunciaFilterDto(string MotivoDenuncia, string FechaDenuncia, string ColoniaDenuncia);
}