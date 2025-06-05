using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ezbuy.Models;
using ezbuy.Services.Interfaces;

namespace ezbuy.Services
{
    public class TokenService : ITokenService
    {
        private const int ExpirationMinutes = 30;
        private readonly ILogger<TokenService> _logger;

        private readonly IJwtService _jwtService;
        private readonly IClaimsService _claimsService;
        private readonly ISignInService _signInService;

        public TokenService(ILogger<TokenService> logger, IJwtService jwtService, IClaimsService claimsService, ISignInService signInService)
        {
            _logger = logger;
            _jwtService = jwtService;
            _claimsService = claimsService;
            _signInService = signInService;
        }

        public string CreateToken(User user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            var token = _jwtService.CreateJwtToken(
                _claimsService.CreateClaims(user),
                _signInService.CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            _logger.LogInformation("JWT Token created");

            return tokenHandler.WriteToken(token);
        }  
    }
}
