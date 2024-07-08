using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Interfaces.IdentityManager;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkillSync.IdentityManager.Services.JWT
{
    public class JwtTokenService : ITokenService
    {
        private readonly string _securityKey;

        public JwtTokenService(IConfiguration config)
        {
            _securityKey = config["JWT:SecurityKey"];
        }

        public string GetToken(User user, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roleClaim = new Claim(ClaimTypes.Role, role);
            var infoClaim = new Claim(ClaimTypes.Email, user.Email);
            var nameClaim = new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}");
            var profilePictureClaim = new Claim("profile-picture", user.ProfilePicture);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Issuer = "Backend",
                Audience = "Frontend",
                Subject = new ClaimsIdentity(new[] { roleClaim, infoClaim, nameClaim, profilePictureClaim }),
                Expires = DateTime.Now.AddHours(5),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptior);
            var tokenString = jwtTokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}