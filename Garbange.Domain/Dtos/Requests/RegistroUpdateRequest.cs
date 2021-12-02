using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos.Requests
{
    public class RegistroUpdateRequest
    {
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NicknameUsuario { get; set; }
        public string ContrasenaUsuario { get; set; }
        public string NivelUsuario { get; set; }
        public string TelefonoUsuario { get; set; }
        public string FechanacUsuario { get; set; }
        public string CorreoUsuario { get; set; }
    }
}