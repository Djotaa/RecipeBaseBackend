using RecipeBase_Backend.Api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RecipeBase_Backend.Api.Core
{
    public class JwtManager
    {
        private AppDbContext dbContext;
        private JwtSettings jwtConfig;

        public JwtManager(AppDbContext dbContext, JwtSettings jwtConfig)
        {
            this.dbContext = dbContext;
            this.jwtConfig = jwtConfig;
        }

        public string CreateToken(string username, string password)
        {
            var user = dbContext.Users.Include(x => x.UseCases).Where(x=>x.IsActive).FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var isValidPw = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isValidPw)
            {
                throw new UnauthorizedAccessException();
            }

            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, jwtConfig.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, jwtConfig.Issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String, jwtConfig.Issuer),
                new Claim("Username", user.Username, ClaimValueTypes.String, jwtConfig.Issuer),
                new Claim("UseCaseIds", JsonConvert.SerializeObject(user.UseCases.Select(x => x.UseCaseId)), ClaimValueTypes.String, jwtConfig.Issuer)
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.PrivateKey));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(jwtConfig.Duration),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
