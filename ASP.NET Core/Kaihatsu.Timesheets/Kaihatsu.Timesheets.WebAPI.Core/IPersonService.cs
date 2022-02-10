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
        Task CreateAsync(Person entity, CancellationToken token);
        Task<IEnumerable<Person>> GetPersonByIdAsync(int id, CancellationToken token);
        Task<IEnumerable<Person>> SearchPersonByNameAsync(string name, CancellationToken token);
        Task<IEnumerable<Person>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken token); 
        Task UpdateAsync(Person entity, CancellationToken token);
        Task DeletePersonByIdAsync(int id, CancellationToken token);
    }
}
