using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TimeService : ITimeService
    {
        private IReposotory<TimeEntity> _reposotory;

        public TimeService(IReposotory<TimeEntity> reposotory)
        {
            _reposotory = reposotory;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _reposotory.DeletAsync(id);
        }

        public async Task<TimeEntity> Get(Guid id)
        {
            return await _reposotory.SelectAsync(id);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _reposotory.SelectAsync();
        }

        public async Task<TimeEntity> Post(TimeEntity time)
        {
            return await _reposotory.InsertAsync(time);
        }

        public async Task<TimeEntity> Put(TimeEntity time)
        {
            return await _reposotory.UpdateAsync(time);
        }
    }
}
