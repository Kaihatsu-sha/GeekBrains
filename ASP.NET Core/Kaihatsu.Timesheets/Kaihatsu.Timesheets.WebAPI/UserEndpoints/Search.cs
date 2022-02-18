using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.UserEndpoints
{
    public partial class UserEndpoint
    {
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IReadOnlyCollection<User>>> SearchUserByName([FromQuery] string searchTerm, CancellationToken token)
        {
            _logger.LogTrace("SearchUserByName searchTerm: {0}", searchTerm);

            IReadOnlyCollection<User> users = await _userService.SearchByNameAsync(searchTerm, token);
            return new ActionResult<IReadOnlyCollection<User>>(users);
        }
    }
}
