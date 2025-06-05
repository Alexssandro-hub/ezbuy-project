using ezbuy.Models;
using ezbuy.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ezbuy.Services
{
    public class ClaimsService : IClaimsService
    {
        public List<Claim> CreateClaims(User user)
        {
            var jwtSub = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];

            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
