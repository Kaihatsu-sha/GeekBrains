using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ClientEndpoints
{
    public partial class ClientEndpoint
    {
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteClientById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("DeleteClientById id: {0}, {1}", id , token);

            await _service.DeleteByIdAsync(id, token);
            return new OkResult();
        }
    }
}
