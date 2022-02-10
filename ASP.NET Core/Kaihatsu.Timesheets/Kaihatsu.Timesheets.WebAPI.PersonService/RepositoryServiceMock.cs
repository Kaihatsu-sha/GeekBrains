using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Services
{
    internal class RepositoryServiceMock : IRepositoryService<Person>
    {

        public Task CreateAsync(Person entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                PersonDbMock.Table.Add(entity);
            });
        }

        public Task DeleteAsync(Person entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                PersonDbMock.Table.Remove(entity);
            });
        }

        public Task<IQueryable<Person>> ReadAllAsync(CancellationToken token)
        {         
            return Task.Run(() =>
            {
                return PersonDbMock.Table.AsQueryable();
            });
        }

        public Task UpdateAsync(Person entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                Person remove = PersonDbMock.Table.FirstOrDefault(x => x.Id == entity.Id);

                PersonDbMock.Table.Remove(remove);
                PersonDbMock.Table.Add(entity);
            });
        }
    }
}
