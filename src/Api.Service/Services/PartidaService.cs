using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PartidaService : IPartidaService
    {
        private IReposotory<PartidaEntity> _reposotory;
        private ITimeService _timeService;

        public PartidaService(IReposotory<PartidaEntity> reposotory, ITimeService timeService)
        {
            _reposotory = reposotory;
            _timeService = timeService;
        }

        public async Task<List<PartidaEntity>> GerarPartidas()
        {
            var times = await _timeService.GetAll();
            List<PartidaEntity> partidas = new List<PartidaEntity>();
            
            foreach (var time1 in times)
            {
                foreach (var time2 in times)
                {
                    if (time1 != time2 && !partidas.Any(x => x.Time1 == time2 && x.Time2 == time1))
                    {
                        var partida = new PartidaEntity();
                        partida.Time1 = time1;
                        partida.Time2 = time2;

                        Random rnd = new Random();
                        partida.Gols1 = rnd.Next(1, 7);
                        partida.Gols2 = rnd.Next(1, 7);

                        partidas.Add(partida);
                    }
                }
            }

            return (partidas);
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
