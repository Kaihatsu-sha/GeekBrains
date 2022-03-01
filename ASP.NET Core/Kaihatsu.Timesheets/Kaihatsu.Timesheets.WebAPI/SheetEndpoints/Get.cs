using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Kaihatsu.Timesheets.WebAPI.SheetEndpoints
{
    public partial class SheetEndpoint
    {
        [HttpGet("{contractId}")]
        public async Task<ActionResult<IReadOnlyCollection<Sheet>>> GetSheetByContractId([FromRoute] int contractId, CancellationToken token)
        {
            _logger.LogTrace("GetSheetByContractId id: {0}", contractId);
            IReadOnlyCollection<Sheet> entities = await _service.GetByIdAsync(contractId, token);
            return new ActionResult<IReadOnlyCollection<Sheet>>(entities);
        }
    }
}
