using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;

namespace Garbange.Domain.Interfaces
{
    public interface IDenunciaService
    {
        bool ValidateCreate(Denuncium denuncium);
        bool ValidateUpdate(Denuncium denuncium);
    }
}