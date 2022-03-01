using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.ContractEndpoints
{
    public partial class ContractEndpoint
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<Contract>>> GetContractById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetContractById id: {0}", id);
            IReadOnlyCollection<Contract> entities = await _service.GetByIdAsync(id, token);
            return new ActionResult<IReadOnlyCollection<Contract>>(entities);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Contract>>> GetContractsFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetContractsFromPagination skip: {0}, take: {1}" + take, skip);

            IReadOnlyCollection<Contract> entities = await _service.GetFromPaginationAsync(skip, take, token);
            return new ActionResult<IReadOnlyCollection<Contract>>(entities);
        }
    }
}
