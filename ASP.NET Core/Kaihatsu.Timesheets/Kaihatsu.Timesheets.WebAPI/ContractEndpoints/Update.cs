using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ContractEndpoints
{
    public partial class ContractEndpoint
    {
        [HttpPut]
        public async Task<ActionResult> UpdateContract ([FromBody] Contract entity, CancellationToken token)
        {
            _logger.LogTrace("UpdateContract {0}", entity);

            await _service.UpdateAsync(entity, token);
            return new OkResult();
        }
    }
}
