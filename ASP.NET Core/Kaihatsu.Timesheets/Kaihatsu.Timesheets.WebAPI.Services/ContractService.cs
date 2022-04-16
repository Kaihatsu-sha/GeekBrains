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
    public class ContractService
    {
        private readonly IRepositoryService<Contract> _repositoryService;

        public ContractService(IRepositoryService<Contract> repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task CreateAsync(Contract entity, CancellationToken token)
        {
            await _repositoryService.CreateAsync(entity, token);
        }

        public async Task<Contract> GetByIdAsync(long id, CancellationToken token)
        {
            IQueryable<Contract> contracts = await _repositoryService.ReadAllAsync();
            Contract contractById = contracts.FirstOrDefault(contract => contract.Id == id);
            _ = contractById ?? throw new ArgumentException($"Not foud by id {id}");

            return contractById;
        }

        public async Task<IReadOnlyCollection<Contract>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Contract> contracts = await _repositoryService.ReadAllAsync();
            return contracts.ToList();
        }
        public async Task UpdateAsync(Contract entity, CancellationToken token)
        {
            await _repositoryService.UpdateAsync(entity, token);
        }
    }
}
