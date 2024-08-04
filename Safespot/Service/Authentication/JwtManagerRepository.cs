using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Safespot.Service.Authentication
{
    public class JwtManagerRepository : IJwtManagerRepository
    {
        Dictionary<string, string> UserRecords = new Dictionary<string, string>()
        {
            { "User1","password1"},
            { "User2","password2"},
            { "User3","password3"}
        };

        private readonly IConfiguration configuration;

        public JwtManagerRepository(IConfiguration iconfiguration)
        {
            this.configuration = iconfiguration;
        }

        public Tokens Authenticate(Users users)
        {
            // if users is not null, then  we generate web token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this.configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
