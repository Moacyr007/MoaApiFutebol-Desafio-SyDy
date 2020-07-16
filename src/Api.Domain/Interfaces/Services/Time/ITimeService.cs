using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Time
{
    public interface ITimeService
    {
        Task<TimeEntity> Get(Guid id);
        Task<IEnumerable<TimeEntity>> GetAll();
        Task<TimeEntity> Post(TimeEntity entity);
        Task<TimeEntity> Put(TimeEntity entity);
        Task<bool> Delete(Guid id);
        Task<List<TimeEntity>> GetTimes(PaginateParameters paginateParameters);
        Task<List<TimeEntity>> FindAll(string nome);
    }
}
