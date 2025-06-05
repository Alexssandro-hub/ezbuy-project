using ezbuy.Models;
using System.Security.Claims;

namespace ezbuy.Services.Interfaces
{
    public interface IClaimsService
    {
        List<Claim> CreateClaims(User user);
    }
}
