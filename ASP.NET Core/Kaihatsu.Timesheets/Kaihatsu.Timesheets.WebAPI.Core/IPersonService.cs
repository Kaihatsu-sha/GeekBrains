using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Core
{
    public interface IPersonService
    {
        Task CreateAsync(User entity, CancellationToken token);
        Task<IEnumerable<User>> GetPersonByIdAsync(int id, CancellationToken token);
        Task<IEnumerable<User>> SearchPersonByNameAsync(string name, CancellationToken token);
        Task<IEnumerable<User>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken token); 
        Task UpdateAsync(User entity, CancellationToken token);
        Task DeletePersonByIdAsync(int id, CancellationToken token);
    }
}
