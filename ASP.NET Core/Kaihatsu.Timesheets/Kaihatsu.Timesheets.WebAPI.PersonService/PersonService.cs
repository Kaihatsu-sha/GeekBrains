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

        public Task CreateAsync(Person entity, CancellationToken token)
        {
            return _repositoryService.CreateAsync(entity, token);
        }

        public Task DeletePersonByIdAsync(int id, CancellationToken token)
        {
            Person person = _repositoryService.ReadAllAsync(token).Result.FirstOrDefault(item => item.Id == id);
            return _repositoryService.DeleteAsync(person, token);
        }

        public Task<IEnumerable<Person>> GetPersonByIdAsync(int id, CancellationToken token)
        {
            IEnumerable<Person> persons = _repositoryService.ReadAllAsync(token).Result.Where(item => item.Id == id);

            return Task.Run(() => persons);
        }

        public Task<IEnumerable<Person>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken token)
        {
            IEnumerable<Person> persons = _repositoryService
                .ReadAllAsync(token)
                .Result
                .Skip(skip)
                .Take(take);

            return Task.Run(() => persons);
        }

        public Task<IEnumerable<Person>> SearchPersonByNameAsync(string name, CancellationToken token)
        {
            IEnumerable<Person> persons = _repositoryService
                .ReadAllAsync(token)
                .Result
                .Where(item => item.FirstName.Contains(name) || item.LastName.Contains(name));

            return Task.Run(() => persons);
        }

        public Task UpdateAsync(Person entity, CancellationToken token)
        {
            return _repositoryService.UpdateAsync(entity, token);
        }
    }
}
