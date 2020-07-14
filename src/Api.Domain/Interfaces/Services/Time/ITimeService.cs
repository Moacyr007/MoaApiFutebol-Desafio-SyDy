using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Time
{
    public interface ITimeService
    {
        Task<TimeEntity> Get(Guid id);
        Task<IEnumerable<TimeEntity>> GetAll ();
        Task<TimeEntity> Post(TimeEntity entity);
        Task<TimeEntity> Put(TimeEntity entity);
        Task<bool> Delete(Guid id);
    }
}
