using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Responses
{
    public class RegistroResponse
    {
        public int IdRegistro { get; set; }
        public string NombreCompleto { get; set; }
        public string InformacionUsuario { get; set; }
    }
}