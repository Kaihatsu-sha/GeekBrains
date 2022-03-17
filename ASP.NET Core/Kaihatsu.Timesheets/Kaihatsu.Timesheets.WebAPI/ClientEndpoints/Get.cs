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
        public async Task<ActionResult<Client>> GetClientById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetClientById id: {0}", id);
            Client client = await _service.GetByIdAsync(id, token);
            return new ActionResult<Client>(client);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Client>>> GetClients( CancellationToken token)
        {
            _logger.LogTrace("GetClients");

            IReadOnlyCollection<Client> entities = await _service.GetClietnsAsync(token);
            return new ActionResult<IReadOnlyCollection<Client>>(entities);
        }
    }
}
