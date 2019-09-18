using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SBoxManager.Data;
using SBoxManager.Data.DTOs.ODO;
using SBoxManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Services
{
    public class HistorialDetalleService : IHistorialDetallesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public HistorialDetalleService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public void Create(HistorialDetalle historialDetalle)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HistorialDetalle Read(int id)
        {
            throw new NotImplementedException();
        }

        
        public List<HistorialDetalle> ReadAll(int id)
        {
            if (_memoryCache.Get("HistorialDetalle") == null)
            {
                List<HistorialDetalle> hds = _dbContext.HitorialDetalles.Where(hd => hd.PacienteHistorialId.Equals(id)).ToList();

                _memoryCache.Set<List<HistorialDetalle>>("HistorialDetalle", hds);
            }

            return _memoryCache.Get<List<HistorialDetalle>>("HistorialDetalle");
        }

        public void Update(HistorialDetalle historialDetalle)
        {
            throw new NotImplementedException();
        }
    }
}
