using System.Collections.Generic;

namespace Application.ViewModels
{
    public class CampeonatoViewModel
    {
        public List<PartidaViewModel> Partidas { get; set; }
        public string campeao { get; set; }
        public string vice { get; set; }
        public string terceiro { get; set; }
    }
}
