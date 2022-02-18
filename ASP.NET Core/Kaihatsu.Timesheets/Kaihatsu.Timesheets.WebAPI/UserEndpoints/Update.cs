using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.UserEndpoints
{
    public partial class UserEndpoint
    {
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] User entity, CancellationToken token)
        {
            _logger.LogTrace("UpdateUser");

            await _userService.UpdateAsync(entity, token);
            return new OkResult();
        }
    }
}
