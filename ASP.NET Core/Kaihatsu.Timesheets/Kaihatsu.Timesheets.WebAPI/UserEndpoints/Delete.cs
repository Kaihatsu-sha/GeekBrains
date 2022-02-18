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
        public async Task<ActionResult> DeleteUserById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("DeleteUserById id: {0}", id);

            await _userService.DeleteByIdAsync(id, token);
            return new OkResult();
        }
    }
}
