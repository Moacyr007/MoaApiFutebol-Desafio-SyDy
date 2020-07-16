using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TimesPaginateViewModel
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdeItens { get; set; }
        public List<TimeEntity> Times { get; set; }
    }
}
