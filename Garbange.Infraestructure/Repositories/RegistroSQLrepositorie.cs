using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;
using Garbange.Infraestructure.Data;
using Garbange.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garbange.Infraestructure.Repositories
{
    public class RegistroSQLrepositorie : IRegistroRepository
    {
        private readonly Garbange4BContext _garbange;
        public RegistroSQLrepositorie(Garbange4BContext garbange)
        {
            _garbange = garbange;
        }

        public async Task<IEnumerable<Registro>> AllDataRegistro()
        {
            var registro = _garbange.Registros.Select(rgt => rgt);
            return await registro.ToListAsync();
        }

        public async Task<Registro> GetById(int id)
        {
            var registro = await _garbange.Registros.FirstOrDefaultAsync(dnc => dnc.IdRegistro == id);
            return registro;
        }

        public async Task<IEnumerable<Registro>> GetByName(string name)
        {
            var registro = _garbange.Registros.Where(rgt => rgt.NombreUsuario == name);
            return await registro.ToListAsync();
        }
        public async Task<int> Create(Registro registro)
        {
            var entity = registro;
            await _garbange.Registros.AddAsync(entity);
            var rows = await _garbange.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("La información del evento no pudo ser completada...");

            return entity.IdRegistro;
        }

        public async Task<bool> Update(int id, Registro registro)
        {
            if(id <= 0 || registro == null)
                throw new ArgumentException("Falta información para poder realizar la modificación...");

            var entity = await GetById(id);

            entity.NombreUsuario = registro.NombreUsuario;
            entity.ApellidoUsuario = registro.ApellidoUsuario;
            entity.NicknameUsuario = registro.NicknameUsuario;
            entity.ContrasenaUsuario = registro.ContrasenaUsuario;
            entity.NivelUsuario = registro.NivelUsuario;
            entity.TelefonoUsuario = registro.TelefonoUsuario;
            entity.FechanacUsuario = registro.FechanacUsuario;
            entity.CorreoUsuario = registro.CorreoUsuario;
            _garbange.Update(entity);
            var rows = await _garbange.SaveChangesAsync();

            return rows > 0;
        }

        public bool Exist(Expression<Func<Registro, bool>> expression)
        {
            return _garbange.Registros.Any(expression);
        }

        public async Task<bool> Delete(int id)
        {
            if(id <= 0)
                throw new ArgumentException("No se encontró el registro proporcionado...");

            var entity = await GetById(id);
            
            _garbange.Remove(entity);

            var rows = await _garbange.SaveChangesAsync();

            return rows > 0;
        }
    }
}