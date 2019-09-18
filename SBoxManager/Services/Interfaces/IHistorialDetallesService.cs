using SBoxManager.Data.DTOs.ODO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Services.Interfaces
{
    public interface IHistorialDetallesService
    {
        List<HistorialDetalle> ReadAll(int id);
        void Create(HistorialDetalle historialDetalle);
        HistorialDetalle Read(int id);
        void Update(HistorialDetalle historialDetalle);
        void Delete(int id);
    }
}
