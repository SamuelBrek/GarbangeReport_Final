using System;
using System.Collections.Generic;

#nullable disable

namespace Garbange.Domain.Entities
{
    public partial class Registro
    {
        public int IdRegistro { get; set; }
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
