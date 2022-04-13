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
        [HttpPost]
        public async Task<ActionResult> CreateSheet([FromBody] SheetDto dto, CancellationToken token)
        {
            _logger.LogTrace("CreateSheet {0} {1}", dto.SpentHours, dto.ContractId);
            try
            {
                await _service.CreateAsync(dto.SpentHours, dto.ContractId, token);
            }
            catch (NullReferenceException nullReference)
            {
                return BadRequest(nullReference.Message);
            }
            return new OkResult();
        }
    }
}
