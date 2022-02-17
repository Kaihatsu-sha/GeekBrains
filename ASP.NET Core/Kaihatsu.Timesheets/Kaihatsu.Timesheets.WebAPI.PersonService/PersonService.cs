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
        private readonly IRepositoryService<User> _repositoryService;

        public PersonService(IRepositoryService<User> repository)
        {
            _repositoryService = repository;
        }

        public Task CreateAsync(User entity, CancellationToken token)
        {
            return _repositoryService.CreateAsync(entity, token);
        }

        public Task DeletePersonByIdAsync(int id, CancellationToken token)
        {
            User person = _repositoryService.ReadAllAsync(token).Result.FirstOrDefault(item => item.Id == id);
            return _repositoryService.DeleteAsync(person, token);
        }

        public Task<IEnumerable<User>> GetPersonByIdAsync(int id, CancellationToken token)
        {
            IEnumerable<User> persons = _repositoryService.ReadAllAsync(token).Result.Where(item => item.Id == id);

            return Task.Run(() => persons);
        }

        public Task<IEnumerable<User>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken token)
        {
            IEnumerable<User> persons = _repositoryService
                .ReadAllAsync(token)
                .Result
                .Skip(skip)
                .Take(take);

            return Task.Run(() => persons);
        }

        public Task<IEnumerable<User>> SearchPersonByNameAsync(string name, CancellationToken token)
        {
            IEnumerable<User> persons = _repositoryService
                .ReadAllAsync(token)
                .Result
                .Where(item => item.FirstName.Contains(name) || item.LastName.Contains(name));

            return Task.Run(() => persons);
        }

        public Task UpdateAsync(User entity, CancellationToken token)
        {
            return _repositoryService.UpdateAsync(entity, token);
        }
    }
}
