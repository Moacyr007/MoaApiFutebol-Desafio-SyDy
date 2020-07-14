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

        //TODO ver se não ter problema esse método não ser assíncrono e os outros serem
        public List<PontuacaoCampeonatoEntity> CalcularPontuacaoCampeonato(List<PartidaEntity> partidas, CampeonatoEntity campeonato, List<TimeEntity> times)
        {
            List<PontuacaoCampeonatoEntity> pontuacoesCampeonato = new List<PontuacaoCampeonatoEntity>();

            //Gera lista de PontuacaoCampeonato com times
            foreach (var time in times)
            {
                var PontuacaoCampeonato = new PontuacaoCampeonatoEntity();
                PontuacaoCampeonato.Time = time;
                pontuacoesCampeonato.Add(PontuacaoCampeonato);
            }

            //Calcula a pontuação de cada time
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
            return (pontuacoesCampeonato);
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
