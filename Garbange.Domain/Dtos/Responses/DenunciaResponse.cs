using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Responses
{
    public class DenunciaResponse
    {
        public int IdDenuncia { get; set; }
        public string InformacionDenuncia { get; set; }
        public string LugarDenuncia { get; set; }
        public string DescripcionDenuncia { get; set; }

    }
}