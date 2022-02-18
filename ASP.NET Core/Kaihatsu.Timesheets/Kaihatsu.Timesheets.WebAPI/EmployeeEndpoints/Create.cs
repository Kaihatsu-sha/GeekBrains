using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    public partial class EmployeeEndpoint
    {
        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee entity, CancellationToken token)
        {
            _logger.LogTrace("CreateEmployee {0} {1}", entity, token);
            try
            {
                await _service.CreateAsync(entity, token);
            }
            catch(NullReferenceException nullReference) 
            {
                return BadRequest(nullReference.Message);
            }
            return new OkResult();
        }
    }
}
