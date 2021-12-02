using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;
using Garbange.Domain.Interfaces;

namespace Garbange.Application.Services
{
    public class RegistroService : IRegistroService
    {
        public bool ValidateCreate(Registro registro)
        {
            if(string.IsNullOrEmpty(registro.NombreUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.ApellidoUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.NicknameUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.ContrasenaUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.NivelUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.TelefonoUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.FechanacUsuario))
                return false;
            
            if(string.IsNullOrEmpty(registro.CorreoUsuario))
                return false;

            return true;
        }

        public bool ValidateUpdate(Registro registro)
        {
            if(registro.IdRegistro <= 0)
                return false;

            if(string.IsNullOrEmpty(registro.NombreUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.ApellidoUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.NicknameUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.ContrasenaUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.NivelUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.TelefonoUsuario))
                return false;

            if(string.IsNullOrEmpty(registro.FechanacUsuario))
                return false;
            
            if(string.IsNullOrEmpty(registro.CorreoUsuario))
                return false;

            return true;
        }
    }
}