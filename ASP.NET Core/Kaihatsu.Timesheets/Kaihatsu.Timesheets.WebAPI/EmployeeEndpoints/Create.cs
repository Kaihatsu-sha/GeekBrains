using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    public partial class EmployeeEndpoint
    {
        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee entity, CancellationToken token)
        {
            _logger.LogTrace("CreateEmployee {0} {1}", entity, token);

            await _service.CreateAsync(entity, token);
            return new OkResult();
        }
    }
}
