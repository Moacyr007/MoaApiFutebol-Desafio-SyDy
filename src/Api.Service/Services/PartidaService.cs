using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Partida;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PartidaService : IPartidaService
    {
        private IReposotory<PartidaEntity> _reposotory;

        public PartidaService(IReposotory<PartidaEntity> reposotory)
        {
            _reposotory = reposotory;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _reposotory.DeletAsync(id);
        }

        public async Task<PartidaEntity> Get(Guid id)
        {
            return await _reposotory.SelectAsync(id);
        }

        public async Task<IEnumerable<PartidaEntity>> GetAll()
        {
            return await _reposotory.SelectAsync();
        }

        public async Task<PartidaEntity> Post(PartidaEntity entity)
        {
            return await _reposotory.InsertAsync(entity);
        }

        public async Task<PartidaEntity> Put(PartidaEntity entity)
        {
            return await _reposotory.UpdateAsync(entity);
        }
    }
}
