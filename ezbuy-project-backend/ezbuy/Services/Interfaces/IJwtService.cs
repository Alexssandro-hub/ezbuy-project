using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ezbuy.Services.Interfaces
{
    public interface IJwtService
    {
        JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration);
    }
}
