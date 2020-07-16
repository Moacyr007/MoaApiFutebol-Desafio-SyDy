using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class CampeonatoEntity : BaseEntity
    {
        public CampeonatoEntity()
        {
            Partidas = new List<PartidaEntity>();
        }
        public virtual List<PartidaEntity> Partidas { get; set; }
        public TimeEntity Campeao { get; set; }
        public TimeEntity Vice { get; set; }
        public TimeEntity Terceiro { get; set; }
    }
}
