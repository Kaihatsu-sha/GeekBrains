using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.InvoiceEndpoints
{
    public partial class InvoiceEndpoint
    {
        [HttpGet("{contractId}")]
        public async Task<ActionResult<IReadOnlyCollection<Invoice>>> GetInvoicetByContractId([FromRoute] int contractId, CancellationToken token)
        {
            _logger.LogTrace("GetInvoicetByContractId id: {0}", contractId);
            IReadOnlyCollection<Invoice> entities = await _service.GetAsync(contractId, token);
            return new ActionResult<IReadOnlyCollection<Invoice>>(entities);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Invoice>>> GetInvoices(CancellationToken token)
        {
            _logger.LogTrace("GetInvoices");
            IReadOnlyCollection<Invoice> contracts = await _service.GetAllAsync(token);
            return new ActionResult<IReadOnlyCollection<Invoice>>(contracts);
        }
    }
}
