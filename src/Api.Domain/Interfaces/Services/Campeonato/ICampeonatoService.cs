using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Campeonato
{
    public interface ICampeonatoService
    {
        Task<CampeonatoEntity> Get(Guid id);
        Task<IEnumerable<CampeonatoEntity>> GetAll();
        Task<CampeonatoEntity> Post(CampeonatoEntity entity);
        Task<CampeonatoEntity> Put(CampeonatoEntity entity);
        Task<bool> Delete(Guid id);

        Task<CampeonatoEntity> GerarCampeonato();
    }
}
