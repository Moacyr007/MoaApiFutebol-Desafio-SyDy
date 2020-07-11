using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PontuacaoCampeonatoEntity : BaseEntity
    {
        //public PontuacaoCampeonatoEntity(TimeEntity time, CampeonatoEntity campeonato)
        //{
        //    Time = time;
        //    Campeonato = campeonato;
        //    //Acho que otime e o campeonato já vão se validar
        //    //TODO ver onde vai ficar a logica de calcular a pontuação
        //}

        public TimeEntity Time { get; set; }
        public CampeonatoEntity Campeonato { get; set; }
        public int Pontuacao { get; set; }
    }
}
