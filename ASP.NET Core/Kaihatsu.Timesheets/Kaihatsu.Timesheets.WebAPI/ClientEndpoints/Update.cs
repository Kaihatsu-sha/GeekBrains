using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ClientEndpoints
{
    public partial class ClientEndpoint
    {
        [HttpPut]
        public async Task<ActionResult> UpdateClient ([FromBody] Client entity, CancellationToken token)
        {
            _logger.LogTrace("UpdateClient {0}", entity);

            await _service.UpdateAsync(entity, token);
            return new OkResult();
        }
    }
}
