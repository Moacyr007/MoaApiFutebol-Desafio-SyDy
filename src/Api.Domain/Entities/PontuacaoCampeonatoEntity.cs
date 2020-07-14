using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Domain.Entities
{
    public class PontuacaoCampeonatoEntity : BaseEntity
    {
        public TimeEntity Time { get; set; }
        public CampeonatoEntity Campeonato { get; set; }
        public int Pontuacao { get; set; }
    }
}
