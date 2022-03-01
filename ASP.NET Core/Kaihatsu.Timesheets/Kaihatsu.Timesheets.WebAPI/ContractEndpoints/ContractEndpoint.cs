using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.ContractEndpoints
{
    [Route("api/v1/contracts")]
    [ApiController]
    [Authorize]
    public partial class ContractEndpoint : ControllerBase
    {
        private readonly ILoggerService<ContractEndpoint> _logger;
        private readonly ContractService _service;

        public ContractEndpoint(ILoggerService<ContractEndpoint> logger, ContractService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
