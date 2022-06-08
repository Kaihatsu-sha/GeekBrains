using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.AuthenticateEndpoints
{
    public partial class AuthenticateEndpoint
    {
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery] string login, [FromQuery] string password)
        {
            (string token, string refreshToken) response = (string.Empty, string.Empty);
            try
            {
                response = _tokenService.Authenticate(login, password).Result;
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }

            var tokenResponse = new { AccessToken = response.token, RefreshToken = response.refreshToken };
            return Ok(tokenResponse);
        }
    }
}
