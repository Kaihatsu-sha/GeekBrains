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
    internal class RepositoryServiceMock : IRepositoryService<User>
    {

        public Task CreateAsync(User entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                PersonDbMock.Table.Add(entity);
            });
        }

        public Task DeleteAsync(User entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                PersonDbMock.Table.Remove(entity);
            });
        }

        public Task<IQueryable<User>> ReadAllAsync(CancellationToken token)
        {         
            return Task.Run(() =>
            {
                return PersonDbMock.Table.AsQueryable();
            });
        }

        public Task UpdateAsync(User entity, CancellationToken token)
        {
            return Task.Run(() =>
            {
                User remove = PersonDbMock.Table.FirstOrDefault(x => x.Id == entity.Id);

                PersonDbMock.Table.Remove(remove);
                PersonDbMock.Table.Add(entity);
            });
        }
    }
}
