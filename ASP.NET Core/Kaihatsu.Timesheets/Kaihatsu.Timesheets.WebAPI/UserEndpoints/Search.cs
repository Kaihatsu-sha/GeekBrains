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
        public async Task<ActionResult<IEnumerable<User>>> SearchPersonByName([FromQuery] string searchTerm, CancellationToken token)
        {
            _logger.LogTrace("SearchPersonByName searchTerm: {0}", searchTerm);

            IEnumerable<User> persons = await _userService.SearchPersonByNameAsync(searchTerm, token);
            return new ActionResult<IEnumerable<User>>(persons);
        }
    }
}
