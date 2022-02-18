using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    public partial class EmployeeEndpoint
    {
        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] Employee entity, CancellationToken token)
        {
            _logger.LogTrace("UpdateEmployee {0}", entity);

            await _service.UpdateAsync(entity, token);
            return new OkResult();
        }
    }
}
