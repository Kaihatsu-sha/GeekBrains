using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using Kaihatsu.Timesheets.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Services
{
    public sealed class PersonService : IPersonService
    {
        private readonly IRepositoryService<Person> _repositoryService;

        public PersonService()
        {
            _repositoryService = new RepositoryServiceMock();
        }

        public async Task CreateAsync(Person entity, CancellationToken token)
        {
            await _repositoryService.CreateAsync(entity, token);
        }

        public async Task DeletePersonByIdAsync(int id, CancellationToken token)
        {
            IQueryable<Person> persons = await _repositoryService.ReadAllAsync(token);
            Person person = persons.FirstOrDefault(item => item.Id == id);
            await _repositoryService.DeleteAsync(person, token);
        }

        public async Task<IEnumerable<Person>> GetPersonByIdAsync(int id, CancellationToken token)
        {
            IQueryable<Person> persons = await _repositoryService.ReadAllAsync(token);
            return persons.Where(item => item.Id == id);
        }

        public async Task<IEnumerable<Person>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken token)
        {
            IQueryable<Person> persons = await _repositoryService.ReadAllAsync(token);
            return persons.Skip(skip).Take(take);
        }

        public async Task<IEnumerable<Person>> SearchPersonByNameAsync(string name, CancellationToken token)
        {
            IQueryable<Person> persons = await _repositoryService.ReadAllAsync(token);
            return persons.Where(item => item.FirstName.Contains(name) || item.LastName.Contains(name));
        }

        public async Task UpdateAsync(Person entity, CancellationToken token)
        {
           await _repositoryService.UpdateAsync(entity, token);
        }
    }
}
