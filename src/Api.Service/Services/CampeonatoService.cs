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
            var times = await _timeService.GetAll();
            var campeonato = new CampeonatoEntity();


            var pontuacoesCampeonato = new List<PontuacaoCampeonatoEntity> { };

            foreach (var time1 in times){

                var pontuacoeCampeonato = new PontuacaoCampeonatoEntity();
                pontuacoeCampeonato.Time = time1;

                pontuacoesCampeonato.Add(pontuacoeCampeonato);

                foreach (var time2 in times)
                {
                    //Gerar partida

                    //TODO ver se não tem uma forma melhor de fazer isso no lugar do if
                    if (time1 != time2 && !campeonato.Partidas.Any(x => x.Time1 == time2 && x.Time2 == time1))
                    {
                        var partida = new PartidaEntity();
                        partida.Time1 = time1;
                        partida.Time2 = time2;

                        Random rnd = new Random();
                        partida.Gols1 = rnd.Next(1, 7);
                        partida.Gols2 = rnd.Next(1, 7);

                        campeonato.Partidas.Add(partida);

                        await _partidaService.Post(partida);
                    }

                }
            }

            var partidas = campeonato.Partidas;

            //Calcula a pontuacao de cada time no campeonato
            foreach (var partida in partidas)
            {
                if (partida.Gols1 > partida.Gols2)
                {
                    var teste = pontuacoesCampeonato.Find(x => x.Time == partida.Time1);

                    teste.Pontuacao += 3;
                }
                else if (partida.Gols1 < partida.Gols2)
                {
                    var teste = pontuacoesCampeonato.Find(x => x.Time == partida.Time2);

                    teste.Pontuacao += 3;
                }
                else
                {
                    var teste = pontuacoesCampeonato.Find(x => x.Time == partida.Time2);
                    teste.Pontuacao += 1;

                    teste = pontuacoesCampeonato.Find(x => x.Time == partida.Time1);
                    teste.Pontuacao += 1;
                }
            }



            var pontuacoesCampeonatoOrdenado = pontuacoesCampeonato.OrderByDescending(x => x.Pontuacao);

            campeonato.Campeao = pontuacoesCampeonatoOrdenado.ElementAt(0).Time;
            campeonato.Vice = pontuacoesCampeonatoOrdenado.ElementAt(1).Time;
            campeonato.Terceiro = pontuacoesCampeonatoOrdenado.ElementAt(2).Time;


            var campeonatoCompleto = await _reposotory.InsertAsync(campeonato);


            foreach (var item in pontuacoesCampeonato)
            {
                item.Campeonato = campeonatoCompleto;

                await _pontuacaoCampeonatoService.Post(item);
            }

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
