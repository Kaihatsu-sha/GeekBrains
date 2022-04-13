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
        public async Task<ActionResult<Contract>> GetContractById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetContractById id: {0}", id);
            Contract contract = await _service.GetByIdAsync(id, token);
            return new ActionResult<Contract>(contract);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Contract>>> GetContracts( CancellationToken token)
        {
            _logger.LogTrace("GetContracts");
            IReadOnlyCollection<Contract> contracts = await _service.GetAllAsync(token);
            return new ActionResult<IReadOnlyCollection<Contract>>(contracts);
        }
    }
}
