using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PaginateParameters
    {
        const int tamanhoMaximoPagina = 50;
        public int Pagina { get; set; } = 1;
		private int _tamanhoPagina = 10;

		//Não deixa setar PageSize além do limite definido(maxPageSize)
		public int TamanhoPagina
		{
			get
			{
				return _tamanhoPagina;
			}
			set
			{
				_tamanhoPagina = (value > tamanhoMaximoPagina) ? tamanhoMaximoPagina : value;
			}
		}
	}
}
