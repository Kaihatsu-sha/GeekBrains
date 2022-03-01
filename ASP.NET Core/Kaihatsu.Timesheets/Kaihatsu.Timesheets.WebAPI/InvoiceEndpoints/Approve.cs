using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.InvoiceEndpoints
{
    public partial class InvoiceEndpoint
    {
        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<IReadOnlyCollection<Invoice>>> ApproveInvoice([FromRoute] int invoiceId, CancellationToken token)
        {
            _logger.LogTrace("ApproveInvoice {0}", invoiceId);

            await _service.UpdateAsync(invoiceId, token);
            return new OkResult();
        }
    }
}
