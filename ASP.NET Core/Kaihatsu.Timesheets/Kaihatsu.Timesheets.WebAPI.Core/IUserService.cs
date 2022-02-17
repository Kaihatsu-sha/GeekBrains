using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Core
{
    public interface IUserService
    {
        Task CreateAsync(User entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<User>> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<User>> SearchPersonByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<User>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task UpdateAsync(User entity, CancellationToken cancellationToken = default);
        Task DeletePersonByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
