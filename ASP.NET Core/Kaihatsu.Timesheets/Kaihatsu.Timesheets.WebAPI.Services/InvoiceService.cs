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
    public class InvoiceService
    {
        private readonly IRepositoryService<Invoice> _repositoryService;
        private readonly IRepositoryService<Contract> _contractRepository;
        private readonly IRepositoryService<Sheet> _sheetRepository;

        public InvoiceService(IRepositoryService<Invoice> repositoryService, IRepositoryService<Contract> contract, IRepositoryService<Sheet> sheet)
        {
            _repositoryService = repositoryService;
            _contractRepository = contract;
            _sheetRepository = sheet;
        }

        public async Task CreateAsync(long contractId, CancellationToken token)
        {
            IQueryable<Contract> contracts = await _contractRepository.ReadAllAsync(token);
            Contract contract = contracts.FirstOrDefault(contract => contract.Id == contractId);
            _ = contract ?? throw new ArgumentException($"Not found by id {contractId}");

            Invoice invoice = new Invoice();
            invoice.Create(contract);

            IQueryable<Sheet> sheets = await _sheetRepository.ReadAllAsync(token);
            IQueryable<Sheet> sheetsByContract = sheets
                .Where(sheet => sheet.Contract.Id == contract.Id);
            invoice.IncludeSheets(sheetsByContract);
            invoice.CalculateSum();

            await _repositoryService.CreateAsync(invoice, token);
        }

        public async Task<IReadOnlyCollection<Invoice>> GetAsync(long contractId, CancellationToken token)
        {
            IQueryable<Invoice> invoices = await _repositoryService.ReadAllAsync(token);
            IReadOnlyCollection<Invoice> invoicesById = invoices
                .Where(invoice => invoice.Contract.Id == contractId)
                .ToList();

            return invoicesById;
        }

        public async Task<IReadOnlyCollection<Invoice>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Invoice> invoices = await _repositoryService.ReadAllAsync();
            return invoices.ToList();
        }

        public async Task ApproveAsync(long invoiceId, CancellationToken token)
        {
            IQueryable<Invoice> invoices = await _repositoryService.ReadAllAsync(token);
            Invoice invoice = invoices.FirstOrDefault(invoice => invoice.Id == invoiceId);
            _ = invoice ?? throw new ArgumentException($"Not found by id {invoiceId}");
            invoice.Approve();

            await _repositoryService.UpdateAsync(invoice);
        }
    }
}
