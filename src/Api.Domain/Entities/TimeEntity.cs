using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TimeEntity : BaseEntity
    {
        public TimeEntity(string nome)
        {
            Nome = nome;

            //TODO validação de nome unico
            //TODO validacao de tamanho minmo e maximo
        }

        public string Nome { get; set; }
    }
}
