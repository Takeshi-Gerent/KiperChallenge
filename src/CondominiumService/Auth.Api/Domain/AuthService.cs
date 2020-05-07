using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.Domain
{
    public class AuthService
    {
        private readonly IUnitOfWork uow;
        private readonly AppSettings appSettings;

        public AuthService(IUnitOfWork uow, IOptions<AppSettings> appSettings)
        {
            this.uow = uow;
            this.appSettings = appSettings.Value;
        }

        public string Authenticate(string userName, string password)
        {
            var user = uow.UserRepository.FindByUserName(userName);

            if (user.Result == null) return null;

            if (!user.Result.PasswordMatches(password)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Result.UserName),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User UserFromUserName(string userName)
        {
            return uow.UserRepository.FindByUserName(userName).Result;
        }
    }
}
