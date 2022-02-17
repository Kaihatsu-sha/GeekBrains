using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.UserEndpoints
{
    public partial class UserEndpoint
    {
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletePersonById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("DeletePersonById id: {0}", id);

            await _userService.DeletePersonByIdAsync(id, token);
            return new OkResult();
        }
    }
}
