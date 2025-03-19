using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagement.API.Utils
{
    public class JWTProvider
    {
        private JWTProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private static JWTProvider? _instance = null;
        public static JWTProvider GetInstance(IConfiguration configuration)
        {
            _instance ??= new JWTProvider(configuration);
            return _instance;
        }

        public string GenerateToken(IList<Claim> claims)
        {
            SigningCredentials credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"] ?? throw new KeyNotFoundException("SecretForKey not found in configuration"),
                audience: _configuration["Authentication:Audience"] ?? throw new KeyNotFoundException("SecretForKey not found in configuration"),
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public SymmetricSecurityKey SecurityKey
        {
            get
            {
                string secretForKey = _configuration["Authentication:SecretForKey"] ?? throw new KeyNotFoundException("SecretForKey not found in configuration");
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretForKey));
                return securityKey;
            }
        }
        private readonly IConfiguration _configuration;
    }
}
