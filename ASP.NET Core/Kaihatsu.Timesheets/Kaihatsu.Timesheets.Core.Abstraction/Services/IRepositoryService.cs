using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Kaihatsu.Timesheets.Core.Abstraction.Services
{
    public interface IRepositoryService<TEntity>
        where TEntity : ItemBase
    {
        //CRUD
        Task CreateAsync(TEntity entity, CancellationToken token);
        Task<IQueryable<TEntity>> ReadAllAsync(CancellationToken token);
        Task UpdateAsync(TEntity entity, CancellationToken token);
        Task DeleteAsync(TEntity entity, CancellationToken token);
    }
}
