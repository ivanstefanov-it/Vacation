using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace JWTSecondDemo
{
    public class JwtAutheticationManager
    {
        private readonly string key;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        {
            {"test", "password" },
            {"ivan", "stefanov" },
            {"test1", "pass" },
        };

        public JwtAutheticationManager(string key)
        {
            this.key = key;
        }

        public string Authtenticate(string username, string password)
        {
            if (!users.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature 
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);



            return tokenHandler.WriteToken(token);
        }
    }
}
