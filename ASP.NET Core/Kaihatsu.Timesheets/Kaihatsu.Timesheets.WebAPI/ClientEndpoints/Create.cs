using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ClientEndpoints
{
    public partial class ClientEndpoint
    {
        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] Client entity, CancellationToken token)
        {
            _logger.LogTrace("CreateClient {0} {1}", entity, token);
            try
            {
                await _service.CreateAsync(entity, token);
            }
            catch(NullReferenceException nullReference) 
            {
                return BadRequest(nullReference.Message);
            }
            return new OkResult();
        }
    }
}
