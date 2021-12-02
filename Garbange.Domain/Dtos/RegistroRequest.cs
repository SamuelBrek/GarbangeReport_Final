using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos
{
    public record RegistroRequest(string nombreUsuario, string apellidoUsuario, 
    string nicknameUsuario, string contrasenaUsuario, string nivelUsuario, string telefonoUsuario, 
    string fechanacUsuario, string correoUsuario);
}