using ezbuy.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ezbuy.Services
{
    public class JwtService : IJwtService
    {
        public JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration) =>
            new(
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
    }
}
