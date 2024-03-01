using ARAINV.Infrastructure.DTOs.Users;
using ARAINV.Infrastructure.Persistence.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ARAINV.Infrastructure.Persistence.Service
{
    internal class JWTService : IJWTService
    {
        public IConfiguration configuration;

        public JWTService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string GenerarToken(UserDTO user)
        {

            var claims = new[]
            {
                new Claim("email", user.EmailUser),
                new Claim("fullName", user.NameUser)
            };

            var llave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetSection("ConfiguracionJwt:Llave").Get<string>() ?? string.Empty));

            var credentials = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}

