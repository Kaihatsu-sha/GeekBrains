using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
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
        private readonly IContractService _service;

        public ContractEndpoint(ILoggerService<ContractEndpoint> logger, IContractService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
