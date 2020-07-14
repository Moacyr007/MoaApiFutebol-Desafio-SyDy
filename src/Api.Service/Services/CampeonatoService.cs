using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.PontuacaoCampeonato;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{

    public class CampeonatoService : ICampeonatoService
    {

        private IReposotory<CampeonatoEntity> _reposotory;
        private ITimeService _timeService;
        private IPartidaService _partidaService;
        private IPontuacaoCampeonatoService _pontuacaoCampeonatoService;

        public CampeonatoService(IReposotory<CampeonatoEntity> reposotory, ITimeService timeService, IPartidaService partidaService,  IPontuacaoCampeonatoService pontuacaoCampeonatoService)
        {
            _reposotory = reposotory;
            _timeService = timeService;
            _partidaService = partidaService;
            _pontuacaoCampeonatoService = pontuacaoCampeonatoService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _reposotory.DeletAsync(id);
        }

        public async Task<CampeonatoEntity> GerarCampeonato()
        {
            List<TimeEntity> times = (List<TimeEntity>)await _timeService.GetAll();
            var campeonato = new CampeonatoEntity();

            var partidas = await _partidaService.GerarPartidas();
            var pontuacoesCampeonato = _pontuacaoCampeonatoService.CalcularPontuacaoCampeonato(partidas, campeonato, times);
            var pontuacoesCampeonatoOrdenado = pontuacoesCampeonato.OrderByDescending(x => x.Pontuacao);

            campeonato.Partidas = partidas;
            campeonato.Campeao = pontuacoesCampeonatoOrdenado.ElementAt(0).Time;
            campeonato.Vice = pontuacoesCampeonatoOrdenado.ElementAt(1).Time;
            campeonato.Terceiro = pontuacoesCampeonatoOrdenado.ElementAt(2).Time;

            var campeonatoCompleto = await _reposotory.InsertAsync(campeonato);

            //Salva pontuacoesCampeonato no banco
            foreach (var item in pontuacoesCampeonato)
            {
                item.Campeonato = campeonatoCompleto;
                await _pontuacaoCampeonatoService.Post(item);
            }

            //Salva partidas no banco
            partidas.ForEach(partida => _partidaService.Post(partida));

            return campeonatoCompleto;

        }

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _reposotory.SelectAsync(id);
        }

        public async Task<IEnumerable<CampeonatoEntity>> GetAll()
        {
            return await _reposotory.SelectAsync();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity campeonato)
        {
            return await _reposotory.InsertAsync(campeonato);
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity campeonato)
        {
            return await _reposotory.UpdateAsync(campeonato);
        }
    }
}
