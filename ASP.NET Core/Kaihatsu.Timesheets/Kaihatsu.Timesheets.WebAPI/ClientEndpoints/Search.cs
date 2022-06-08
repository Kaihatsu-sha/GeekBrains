using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ClientEndpoints
{
    public partial class ClientEndpoint
    {
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IReadOnlyCollection<Client>>> SearchClientByName([FromQuery] string searchTerm, CancellationToken token)
        {
            _logger.LogTrace("SearchClientByName searchTerm: {0}", searchTerm);

            IReadOnlyCollection<Client> entities = await _service.SearchByNameAsync(searchTerm, token);
            return new ActionResult<IReadOnlyCollection<Client>>(entities);
        }
    }
}
