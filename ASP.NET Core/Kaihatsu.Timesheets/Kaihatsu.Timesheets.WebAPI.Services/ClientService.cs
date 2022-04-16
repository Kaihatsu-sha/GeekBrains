using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Services
{
    public class ClientService
    {
        private readonly IRepositoryService<Client> _repositoryService;

        public ClientService(IRepositoryService<Client> repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task CreateAsync(Client entity, CancellationToken token)
        {
            await _repositoryService.CreateAsync(entity, token);
        }

        public async Task DeleteByIdAsync(long id, CancellationToken token)
        {
            IQueryable<Client> clients = await _repositoryService.ReadAllAsync(token);
            Client clientById = clients.FirstOrDefault(client => client.Id == id);
            _ = clientById ?? throw new ArgumentException($"Not foud by id {id}");
            await _repositoryService.DeleteAsync(clientById, token);
        }

        public async Task UpdateAsync(Client entity, CancellationToken token)
        {
            await _repositoryService.UpdateAsync(entity, token);
        }

        public async Task<Client> GetByIdAsync(long id, CancellationToken token)
        {
            IQueryable<Client> clients = await _repositoryService.ReadAllAsync(token);
            Client clientById = clients.FirstOrDefault(client => client.Id == id);
            _ = clientById ?? throw new ArgumentException($"Not foud by id {id}");

            return clientById;
        }

        public async Task<IReadOnlyCollection<Client>> GetClietnsAsync(CancellationToken token)
        {
            IQueryable<Client> clients = await _repositoryService.ReadAllAsync(token);
            return clients.ToList();
        }

        public async Task<IReadOnlyCollection<Client>> SearchByNameAsync(string searchTerm, CancellationToken token)
        {
            IQueryable<Client> clients = await _repositoryService.ReadAllAsync(token);
            IReadOnlyCollection<Client> clientsSearch = clients.Where(client => 
                client.User.FirstName.Contains(searchTerm) ||
                client.User.MiddleName.Contains(searchTerm) ||
                client.User.LastName.Contains(searchTerm))
                .ToList();

            return clientsSearch;
        }
    }
}
