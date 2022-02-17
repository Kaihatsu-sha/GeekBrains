using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.Timesheets.WebAPI.UserEndpoints
{
    [Route("api/v1/users")]
    [ApiController]
    public partial class UserEndpoint : ControllerBase
    {
        protected readonly ILoggerService<UserEndpoint> _logger;
        protected readonly IUserService _userService;

        public UserEndpoint(ILoggerService<UserEndpoint> logger, IUserService service)
        {
            _logger = logger;
            _userService = service;
        }
    }
}
