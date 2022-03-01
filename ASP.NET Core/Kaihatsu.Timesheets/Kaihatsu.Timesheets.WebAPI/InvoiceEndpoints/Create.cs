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
        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] int contractId, CancellationToken token)
        {
            _logger.LogTrace("CreateInvoice id: {0}", contractId);
            try
            {
                await _service.CreateAsync(contractId, token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}
