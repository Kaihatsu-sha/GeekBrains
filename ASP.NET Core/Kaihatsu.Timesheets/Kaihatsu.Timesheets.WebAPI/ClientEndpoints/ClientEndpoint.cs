﻿using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.ClientEndpoints
{
    [Route("api/v1/clients")]
    [ApiController]
    [Authorize]
    public partial class ClientEndpoint : ControllerBase
    {
        private readonly ILoggerService<ClientEndpoint> _logger;
        private readonly ClientService _service;

        public ClientEndpoint(ILoggerService<ClientEndpoint> logger, ClientService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
