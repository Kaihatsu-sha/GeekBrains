using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.InvoiceEndpoints
{
    [Route("api/v1/invoices")]
    [ApiController]
    [Authorize]
    public partial class InvoiceEndpoint : ControllerBase
    {
        private readonly ILoggerService<InvoiceEndpoint> _logger;
        private readonly IInvoiceService _service;

        public InvoiceEndpoint(ILoggerService<InvoiceEndpoint> logger, IInvoiceService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
