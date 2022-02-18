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
        [Route("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<Employee>>> GetEmployeeById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetEmployeeById id: {0}", id);
            IReadOnlyCollection<Employee> employees = await _service.GetByIdAsync(id, token);
            return new ActionResult<IReadOnlyCollection<Employee>>(employees);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Employee>>> GetEmployeesFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetEmployeesFromPagination skip: {0}, take: {1}" + take, skip);

            IReadOnlyCollection<Employee> employees = await _service.GetFromPaginationAsync(skip, take, token);
            return new ActionResult<IReadOnlyCollection<Employee>>(employees);
        }
    }
}
