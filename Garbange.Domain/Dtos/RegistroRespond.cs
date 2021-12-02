using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbange.Domain.Dtos
{
    public record RegistroRespond(int idRegistro, string nombreUsuario, string nicknameUsuario, string telefonoUsuario, 
    string fechanacUsuario, string correoUsuario);
}