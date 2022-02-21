using Kaihatsu.Timesheets.Core.Abstraction;
using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Cryptography;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Kaihatsu.Timesheets.Core.Identity
{
    public class IdentityTokenService : IIdentityTokenService
    {
        private readonly IRepositoryService<User> _repository;
        private readonly IRepositoryService<RefreshToken> _repositoryToken;
        private readonly ILoggerService<IdentityTokenService> _logger;
        public IdentityTokenService(IRepositoryService<User> repository, ILoggerService<IdentityTokenService> logger, IRepositoryService<RefreshToken> token)
        {
            _repository = repository;
            _logger = logger;
            _repositoryToken = token;
        }

        public async Task<(string token, string refreshToken)> Authenticate(string login, string password)
        {
            User user = GetUserByLogin(login, password).Result;
            string token = GenerateJwtToken(login, 1);
            var refreshToken = GenerateRefreshJwtToken(login, 300);

            await _repositoryToken.CreateAsync(refreshToken);
            _logger.LogTrace($"{user.Id} {user.Email} ; {refreshToken.Token} {refreshToken.Login}");
            return (token, refreshToken.Token);
        }
        private async Task<User> GetUserByLogin(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException($"{nameof(login)} or {nameof(password)} is null or empty");
            }

            //Get user from BD
            var users = await _repository.ReadAllAsync() ;
            var user = users.Where(user => user.Email.ToLower() == login.ToLower()).FirstOrDefault();
            _ = user ?? throw new ArgumentNullException($"{nameof(login)} user not found");
            //Check user.password
            if (user.PasswordHash.GetHashCode() != password.GetHashCode())
            {
                throw new ArgumentException($"{nameof(password)} не корректный!");
            }

            return user;
        }

        private async Task<RefreshToken> GetTokenByToken(string oldToken)
        {
            if (string.IsNullOrWhiteSpace(oldToken))
            {
                throw new ArgumentNullException($"{nameof(oldToken)} is null or empty");
            }

            //Get user from BD
            var tokens = await _repositoryToken.ReadAllAsync();
            var token = tokens.Where(item => item.Token == oldToken).FirstOrDefault();
            _ = token ?? throw new ArgumentNullException("Login not found");
            //Check user.password
            if (token.IsExpired)
            {
                throw new ArgumentException($"{nameof(token)} устарел!");
            }

            return token;
        }

        private string GenerateJwtToken(string login, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login)
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshJwtToken(string login, int minutes)
        {
            RefreshToken refresh = new RefreshToken();
            refresh.Expires = DateTime.UtcNow.AddMinutes(minutes);
            refresh.Token = GenerateJwtToken(login, minutes);
            refresh.Login = login;

            return refresh;
        }

        public async Task<(string token, string refreshToken)> RefreshToken(string oldRefreshToken)
        {
            RefreshToken reToken = GetTokenByToken(oldRefreshToken).Result;
            string token = GenerateJwtToken(reToken.Login, 1);
            var refreshToken = GenerateRefreshJwtToken(reToken.Login, 300);

            reToken.Expires = refreshToken.Expires;
            reToken.Token = refreshToken.Token;
            await _repositoryToken.UpdateAsync(reToken);

            return (token, refreshToken.Token);
        }

        private bool CheckPassword()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(salt);
            }

            string hashSet =  Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password:"",
                salt,
                KeyDerivationPrf.HMACSHA256,
                10_000,
                256/8));


            return false;
        }
    }
}