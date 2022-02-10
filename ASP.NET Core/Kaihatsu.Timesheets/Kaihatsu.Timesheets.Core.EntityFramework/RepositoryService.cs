using Kaihatsu.Timesheets.Core.Abstraction.Data;
using Kaihatsu.Timesheets.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.EntityFramework
{
    public sealed class RepositoryService<TEntity> : IRepositoryService<TEntity>
        where TEntity : ItemBase
    {
        public RepositoryService()
        {
            
        }

        public async Task CreateAsync(TEntity entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TEntity>> ReadAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
