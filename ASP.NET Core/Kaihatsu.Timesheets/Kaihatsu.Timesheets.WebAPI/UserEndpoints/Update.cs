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
        public async Task<ActionResult> UpdatePerson([FromBody] User person, CancellationToken token)
        {
            _logger.LogTrace("UpdatePerson");

            await _userService.UpdateAsync(person, token);
            return new OkResult();
        }
    }
}
