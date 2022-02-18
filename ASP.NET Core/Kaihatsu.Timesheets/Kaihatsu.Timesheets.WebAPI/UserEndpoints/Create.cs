using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.UserEndpoints
{
    public partial class UserEndpoint
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User entity, CancellationToken token)
        {
            _logger.LogTrace("CreateUser {0} {1}", entity, token);

            await _userService.CreateAsync(entity, token);
            return new OkResult();
        }
    }
}
