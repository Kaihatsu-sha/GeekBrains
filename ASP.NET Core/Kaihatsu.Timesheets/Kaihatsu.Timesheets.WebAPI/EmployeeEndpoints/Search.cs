using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    public partial class EmployeeEndpoint
    {
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IReadOnlyCollection<Employee>>> SearchEmployeeByName([FromQuery] string searchTerm, CancellationToken token)
        {
            _logger.LogTrace("SearchEmployeeByName searchTerm: {0}", searchTerm);

            IReadOnlyCollection<Employee> employees = await _service.SearchByNameAsync(searchTerm, token);
            return new ActionResult<IReadOnlyCollection<Employee>>(employees);
        }
    }
}
