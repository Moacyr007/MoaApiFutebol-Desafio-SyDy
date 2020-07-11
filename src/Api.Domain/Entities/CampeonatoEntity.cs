using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class CampeonatoEntity : BaseEntity
    {
        //public CampeonatoEntity(ICollection<PartidaEntity> partidas)
        //{
        //    //TODO ver em que camada vai ficar o logica de calcular as posicoes
        //}

        public ICollection<PartidaEntity> Partidas { get; set; }
        public TimeEntity Campeao { get; set; }
        public TimeEntity Vice { get; set; }
        public TimeEntity Terceiro { get; set; }
    }
}
