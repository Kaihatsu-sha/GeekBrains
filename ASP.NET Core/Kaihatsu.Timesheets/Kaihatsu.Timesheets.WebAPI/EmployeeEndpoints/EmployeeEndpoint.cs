using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.EmployeeEndpoints
{
    [Route("api/v1/employees")]
    [ApiController]
    [Authorize]
    public partial class EmployeeEndpoint : ControllerBase
    {
        private readonly ILoggerService<EmployeeEndpoint> _logger;
        private readonly IEmployeeService _service;

        public EmployeeEndpoint(ILoggerService<EmployeeEndpoint> logger, IEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
