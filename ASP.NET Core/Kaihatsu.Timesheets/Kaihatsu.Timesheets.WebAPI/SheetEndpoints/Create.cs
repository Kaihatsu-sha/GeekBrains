using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.SheetEndpoints
{
    public partial class SheetEndpoint
    {
        [HttpPost]
        public async Task<ActionResult> CreateSheet([FromBody] int SpentHours,[FromBody] long contractId, CancellationToken token)
        {
            _logger.LogTrace("CreateSheet {0} {1}", SpentHours, contractId);
            try
            {
                await _service.CreateAsync(SpentHours, contractId, token);
            }
            catch (NullReferenceException nullReference)
            {
                return BadRequest(nullReference.Message);
            }
            return new OkResult();
        }
    }
}
