using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
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
        private readonly ISheetService _service;

        public SheetEndpoint(ILoggerService<SheetEndpoint> logger, ISheetService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
