using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.AuthenticateEndpoints
{
    [Route("api/v1/authenticate")]
    [ApiController]
    [AllowAnonymous]
    public partial class AuthenticateEndpoint : ControllerBase
    {
        private readonly ILoggerService<AuthenticateEndpoint> _logger;
        private readonly IIdentityTokenService _tokenService;
        public AuthenticateEndpoint(ILoggerService<AuthenticateEndpoint> logger, IIdentityTokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }
    }
}
