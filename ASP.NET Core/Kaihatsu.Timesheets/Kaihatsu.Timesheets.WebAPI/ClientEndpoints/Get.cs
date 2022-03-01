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
        [Route("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<Client>>> GetClientById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetClientById id: {0}", id);
            IReadOnlyCollection<Client> entities = await _service.GetByIdAsync(id, token);
            return new ActionResult<IReadOnlyCollection<Client>>(entities);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Employee>>> GetClientsFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetClientsFromPagination skip: {0}, take: {1}" + take, skip);

            IReadOnlyCollection<Client> entities = await _service.GetFromPaginationAsync(skip, take, token);
            return new ActionResult<IReadOnlyCollection<Client>>(entities);
        }
    }
}
