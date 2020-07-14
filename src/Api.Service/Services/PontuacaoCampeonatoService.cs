using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.PontuacaoCampeonato;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PontuacaoCampeonatoService : IPontuacaoCampeonatoService
    {
        private IReposotory<PontuacaoCampeonatoEntity> _reposotory;

        public PontuacaoCampeonatoService(IReposotory<PontuacaoCampeonatoEntity> reposotory)
        {
            _reposotory = reposotory;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _reposotory.DeletAsync(id);
        }

        public async Task<PontuacaoCampeonatoEntity> Get(Guid id)
        {
            return await _reposotory.SelectAsync(id);
        }

        public async Task<IEnumerable<PontuacaoCampeonatoEntity>> GetAll()
        {
            return await _reposotory.SelectAsync();
        }

        public async Task<PontuacaoCampeonatoEntity> Post(PontuacaoCampeonatoEntity entity)
        {
            return await _reposotory.InsertAsync(entity);
        }   


        public async Task<PontuacaoCampeonatoEntity> Put(PontuacaoCampeonatoEntity entity)
        {
            return await _reposotory.UpdateAsync(entity);
        }
    }
}
