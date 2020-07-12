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
        Task<IEnumerable<CampeonatoEntity>> GetAll(Guid id);
        Task<CampeonatoEntity> Post(CampeonatoEntity time);
        Task<CampeonatoEntity> Put(CampeonatoEntity time);
        Task<bool> Delete(Guid id);

        Task GerarCampeonato(CampeonatoEntity campeonato);
    }
}
