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
    public class SheetService
    {
        private readonly IRepositoryService<Sheet> _repositoryService;
        private readonly IRepositoryService<Contract> _contractRepository;

        public SheetService(IRepositoryService<Sheet> repositoryService, IRepositoryService<Contract> contract)
        {
            _repositoryService = repositoryService;
            _contractRepository = contract;
        }

        public async Task CreateAsync(int spentHours, long contractId, CancellationToken token)
        {
            IQueryable<Contract> contracts = await _contractRepository.ReadAllAsync(token);
            Contract contract = contracts.FirstOrDefault(contract => contract.Id == contractId);
            _ = contract ?? throw new ArgumentException($"Not found by id {contractId}");

            Sheet sheet = new Sheet();
            sheet.Create(spentHours, contract);  
            await _repositoryService.CreateAsync(sheet, token);
        }

        public async Task<IReadOnlyCollection<Sheet>> GetAsync(long contractId, CancellationToken token)
        {
            IQueryable<Sheet> sheets = await _repositoryService.ReadAllAsync(token);
            IReadOnlyCollection<Sheet> sheetsById = sheets
                .Where(sheet => sheet.Contract.Id == contractId)
                .ToList();

            return sheetsById;
        }

        public async Task<IReadOnlyCollection<Sheet>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Sheet> sheets = await _repositoryService.ReadAllAsync();
            return sheets.ToList();
        }
    }
}
