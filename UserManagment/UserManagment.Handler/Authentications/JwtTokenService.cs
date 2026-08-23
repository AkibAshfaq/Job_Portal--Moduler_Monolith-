using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UserManagment.DTO.DTO;
using UserManagment.Handler.Authentications.Interfaces;

namespace UserManagment.Handler.Authentications 
{
    public class JwtTokenService : IJwtTokenService
    {
        private static readonly JsonWebTokenHandler Handler = new();
        private readonly JwtSettings _settings;

        public JwtTokenService(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GetJwtToken(AuthenticatedUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_settings.ExpirationDate)),
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(
                [
                     new Claim(JwtRegisteredClaimNames.Sub, user.id),
                     new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(ClaimTypes.NameIdentifier, user.id),
                     new Claim(ClaimTypes.Name, user.FullName),
                     new Claim(ClaimTypes.Role, user.Role),
                ])
            };
            return Handler.CreateToken(descriptor);
        }

    }
}
