using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    public partial class EmployeeEndpoint
    {
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEmployeeById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("DeleteEmployeeById id: {0}, {1}", id , token);

            await _service.DeleteByIdAsync(id, token);
            return new OkResult();
        }
    }
}
