using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Infraestructure.Data;
using Garbange.Domain.Entities;
using Garbange.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garbange.Infraestructure.Repositories
{
    public class DenunciaSQLrepositorie : IDenunciaRepository
    {
        private readonly Garbange4BContext _garbange;

        public DenunciaSQLrepositorie(Garbange4BContext garbange)
        {
            _garbange = garbange;
        }

        public async Task<IEnumerable<Denuncium>> AllDataDenuncia()
        {
            var denuncia = _garbange.Denuncia.Select(dnc => dnc);
            return await denuncia.ToListAsync();
        }
        public async Task<Denuncium> GetById(int id)
        {
            var denuncia = await _garbange.Denuncia.FirstOrDefaultAsync(dnc => dnc.IdDenuncia == id);
            return denuncia;
        }
        public async Task<IEnumerable<Denuncium>> GetByColonia(string colonia)
        {
            var denuncia = _garbange.Denuncia.Where(dnc => dnc.ColoniaDenuncia == colonia);
            return await denuncia.ToListAsync();
        }

        public async Task<int> Create(Denuncium denuncium)
        {
            var entity = denuncium;
            await _garbange.Denuncia.AddAsync(entity);
            var rows = await _garbange.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("La información de la denuncia no pudo ser completada...");

            return entity.IdDenuncia;
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

        public async Task<IEnumerable<Denuncium>> GetByFilter(Denuncium denuncium)
        {
            if (denuncium == null) return new List<Denuncium>();
            var query = _garbange.Denuncia.Select(x => x);
            if (!string.IsNullOrEmpty(denuncium.MotivoDenuncia))    
                query =
                    query.Where(x => x.MotivoDenuncia.Contains(denuncium.MotivoDenuncia));

            if (!string.IsNullOrEmpty(denuncium.FechaDenuncia))
                query =
                    query.Where(x => x.FechaDenuncia.Contains(denuncium.FechaDenuncia));
            
            if (!string.IsNullOrEmpty(denuncium.ColoniaDenuncia))
                query = query.Where(x => x.ColoniaDenuncia == denuncium.ColoniaDenuncia);
            return await query.ToListAsync();
        }

        public async Task<bool> Update(int id, Denuncium denuncia)
        {
            if(id <= 0 || denuncia == null)
                throw new ArgumentException("Falta información para poder realizar la modificación...");

            var entity = await GetById(id);
            
            entity.MotivoDenuncia = denuncia.MotivoDenuncia;
            entity.FechaDenuncia = denuncia.FechaDenuncia;
            entity.DescripcionDenuncia = denuncia.DescripcionDenuncia;
            entity.UbicacionDenuncia = denuncia.UbicacionDenuncia;
            entity.ColoniaDenuncia = denuncia.ColoniaDenuncia;
            entity.ImagenDenuncia = denuncia.ImagenDenuncia;
            _garbange.Update(entity);
            var rows = await _garbange.SaveChangesAsync();

            return rows > 0;
        }
    }
}