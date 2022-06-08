using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.Abstraction.Services
{
    public interface IIdentityTokenService
    {
        Task<(string token, string refreshToken)> Authenticate(string login, string password);
        Task<(string token, string refreshToken)> RefreshToken(string oldRefreshToken); 
    }
}
