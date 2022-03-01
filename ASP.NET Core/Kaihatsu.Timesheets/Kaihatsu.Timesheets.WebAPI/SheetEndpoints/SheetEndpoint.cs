using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.SheetEndpoints
{
    [Route("api/v1/sheets")]
    [ApiController]
    [Authorize]
    public partial class SheetEndpoint : ControllerBase
    {
        private readonly ILoggerService<SheetEndpoint> _logger;
        private readonly SheetService _service;

        public SheetEndpoint(ILoggerService<SheetEndpoint> logger, SheetService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
