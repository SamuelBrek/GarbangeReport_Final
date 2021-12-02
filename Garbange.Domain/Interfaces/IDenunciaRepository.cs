using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;

namespace Garbange.Domain.Interfaces
{
    public interface IDenunciaRepository
    {
        Task<IEnumerable<Denuncium>> AllDataDenuncia();
        Task<IEnumerable<Denuncium>> GetByColonia(string colonia);
        Task<Denuncium> GetById(int id);
        Task<int> Create(Denuncium denuncium);
        Task<bool> Update(int id, Denuncium denuncium);
        Task<bool> Delete(int id);
        Task<IEnumerable<Denuncium>> GetByFilter(Denuncium denuncium);

    }
}