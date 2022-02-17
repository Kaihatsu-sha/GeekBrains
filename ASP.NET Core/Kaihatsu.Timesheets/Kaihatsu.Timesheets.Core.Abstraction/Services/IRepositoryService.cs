using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Kaihatsu.Timesheets.Core.Abstraction.Services
{
    public interface IRepositoryService<T>
        where T : ItemBase
    {
        //CRUD
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<IQueryable<T>> ReadAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
