using Microsoft.IdentityModel.Tokens;

namespace ezbuy.Services.Interfaces
{
    public interface ISignInService
    {
        SigningCredentials CreateSigningCredentials();
    }
}
