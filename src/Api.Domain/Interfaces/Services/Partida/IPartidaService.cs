using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Partida
{
    public interface IPartidaService
    {
        Task<PartidaEntity> Get(Guid id);
        Task<IEnumerable<PartidaEntity>> GetAll();
        Task<PartidaEntity> Post(PartidaEntity entity);
        Task<PartidaEntity> Put(PartidaEntity entity);
        Task<bool> Delete(Guid id);
        Task<List<PartidaEntity>> GerarPartidas();
    }
}
