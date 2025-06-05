using ezbuy.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ezbuy.Services.Interfaces
{
    public interface ITokenService 
    {
        string CreateToken(User user); 
    }
}
