using ezbuy.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ezbuy.Services
{
    public class SignInService : ISignInService
    {
        public SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
