using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Garbange.Domain.Entities;


namespace Garbange.Domain.Interfaces
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<Registro>> AllDataRegistro();
        Task<IEnumerable<Registro>> GetByName(string name);
        Task<Registro> GetById(int id);
        Task<int> Create(Registro registro);
        Task<bool> Update(int id, Registro registro);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Registro, bool>> expression);

    }
}