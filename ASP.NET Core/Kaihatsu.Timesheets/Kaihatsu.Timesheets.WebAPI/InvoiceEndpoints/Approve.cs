using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
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

            try
            {
                await _service.ApproveAsync(invoiceId, token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return  new OkResult();
        }
    }
}
