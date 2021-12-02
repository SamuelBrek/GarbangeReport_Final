using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;
using Garbange.Domain.Interfaces;

namespace Garbange.Application.Services
{
    public class DenunciaService : IDenunciaService
    {
        public bool ValidateCreate(Denuncium denuncium)
        {
            if(string.IsNullOrEmpty(denuncium.MotivoDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.FechaDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.DescripcionDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.UbicacionDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.ColoniaDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.ImagenDenuncia))
                return false;

            return true;
        }

        public bool ValidateUpdate(Denuncium denuncium)
        {
            if (denuncium.IdDenuncia <= 0)
                return false;
                
            if(string.IsNullOrEmpty(denuncium.MotivoDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.FechaDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.DescripcionDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.UbicacionDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.ColoniaDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncium.ImagenDenuncia))
                return false;

            return true;
        }
    }
}