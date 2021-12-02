using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;

namespace Garbange.Domain.Interfaces
{
    public interface IRegistroService
    {
        bool ValidateCreate(Registro registro);
        bool ValidateUpdate(Registro registro);
    }
}