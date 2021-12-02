using System;
using System.Collections.Generic;

#nullable disable

namespace Garbange.Domain.Entities
{
    public partial class Denuncium
    {
        
        public int IdDenuncia { get; set; }
        public string MotivoDenuncia { get; set; }
        public string FechaDenuncia { get; set; }
        public string DescripcionDenuncia { get; set; }
        public string UbicacionDenuncia { get; set; }
        public string ColoniaDenuncia { get; set; }
        public string ImagenDenuncia { get; set; }
    }
}
