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
        [Route("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<User>>> GetUserById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetUserById id: {0}", id);
            IReadOnlyCollection<User> users = await _userService.GetByIdAsync(id, token);
            return new ActionResult<IReadOnlyCollection<User>>(users);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<User>>> GetUsersFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetUsersFromPagination skip: {0}, take: " + take, skip);

            IReadOnlyCollection<User> users = await _userService.GetFromPaginationAsync(skip, take, token);
            return new ActionResult<IReadOnlyCollection<User>>(users);
        }
    }
}
