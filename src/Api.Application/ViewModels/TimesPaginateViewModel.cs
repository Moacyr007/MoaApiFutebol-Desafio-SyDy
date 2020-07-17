using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class TimesPaginateViewModel
    {
        public TimesPaginateViewModel()
        {
            Times = new List<TimeViewModel>();
        }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdeItens { get; set; }
        public List<TimeViewModel> Times { get; set; }
    }
}