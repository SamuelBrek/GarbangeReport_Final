using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Requests
{
    public class DenunciaUpdateRequest
    {
        public string MotivoDenuncia { get; set; }
        public string FechaDenuncia { get; set; }
        public string DescripcionDenuncia { get; set; }
        public string UbicacionDenuncia { get; set; }
        public string ColoniaDenuncia { get; set; }
        public string ImagenDenuncia { get; set; }
    }
}