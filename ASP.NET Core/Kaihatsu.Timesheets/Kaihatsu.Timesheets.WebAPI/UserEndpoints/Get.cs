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
        public async Task<ActionResult<IEnumerable<User>>> GetPersonById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetPersonById id: {0}", id);
            IEnumerable<User> persons = await _userService.GetPersonByIdAsync(id, token);
            return new ActionResult<IEnumerable<User>>(persons);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetPersonsFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetPersonsFromPagination skip: {0}, take: " + take, skip);

            IEnumerable<User> persons = await _userService.GetPersonsFromPaginationAsync(skip, take, token);
            return new ActionResult<IEnumerable<User>>(persons);
        }
    }
}
