using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Core
{
    public interface IBaseService<T> where T : ItemBase
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> SearchByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> GetFromPaginationAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
