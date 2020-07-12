using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private IReposotory<CampeonatoEntity> _reposotory;

        public CampeonatoService(IReposotory<CampeonatoEntity> reposotory)
        {
            _reposotory = reposotory;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _reposotory.DeletAsync(id);
        }

        public Task GerarCampeonato(CampeonatoEntity campeonato)
        {
            throw new NotImplementedException();
             //TODO implementar regra pra gerar o campeonato e retornato como no exemplod da SyDy
        }

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _reposotory.SelectAsync(id);
        }

        public async Task<IEnumerable<CampeonatoEntity>> GetAll(Guid id)
        {
            return await _reposotory.SelectAsync();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity time)
        {
            return await _reposotory.InsertAsync(time);
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity time)
        {
            return await _reposotory.UpdateAsync(time);
        }
    }
}
