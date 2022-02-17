using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryService<User> _repositoryService;

        public UserService(IRepositoryService<User> repository)
        {
            _repositoryService = repository;
        }

        public async Task CreateAsync(User entity, CancellationToken cancellationToken = default)
        {
            await _repositoryService.CreateAsync(entity, cancellationToken);
        }

        public async Task DeletePersonByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            IQueryable<User> users = await _repositoryService.ReadAllAsync(cancellationToken);
            User deleteUser = users.FirstOrDefault(item => item.Id == id);
            await _repositoryService.DeleteAsync(deleteUser, cancellationToken);
        }

        public async Task<IReadOnlyCollection<User>> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            IQueryable<User> allUsers = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<User> users = allUsers.Where(item => item.Id == id).ToList();

            return users;
        }

        public async Task<IReadOnlyCollection<User>> GetPersonsFromPaginationAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            IQueryable<User> allUsers = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<User> users = allUsers
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public async Task<IReadOnlyCollection<User>> SearchPersonByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            IQueryable<User> allUsers = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<User> users = allUsers
                .Where(item => item.FirstName.ToLower().Contains(name)
                    || item.MiddleName.ToLower().Contains(name)
                    || item.LastName.ToLower().Contains(name))
                .ToList();

            return users;
        }

        public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            await _repositoryService.UpdateAsync(entity, cancellationToken);
        }
    }
}
