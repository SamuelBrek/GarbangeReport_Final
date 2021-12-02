using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Entities;

namespace Garbange.Domain.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> AllDataEvento();
        Task<IEnumerable<Evento>> GetByEvento(string nameEvento);
        Task<Evento> GetById(int id);
        Task<int> Create(Evento evento);
        Task<bool> Update(int id, Evento evento);
        Task<bool> Delete(int id);


    }
}