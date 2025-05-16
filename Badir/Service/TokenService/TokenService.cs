using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Badir.Service.TokenService;


    public class TokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            var token = Environment.GetEnvironmentVariable("TOKEN");
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception(" ##################################   TOKEN is missing   ##################################");
            }
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));
        }

        public string CreateToken(User user, int? time)
        {
            ArgumentNullException.ThrowIfNull(user);
            var claims = GenerateClaims(user);
            var token = CreateJwtToken(claims, time);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private List<Claim> GenerateClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()!),
                new Claim("Role", user.Role.ToString()!),
            };

            // إضافة الأذونات كـ Claims
            if (user.Permission != null)
            {
                foreach (var permission in user.Permission)
                {
                    claims.Add(new Claim("Permission", permission.PermissionType.ToString()));
                }
            }
            return claims;
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, int? time)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            return new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMonths(time ?? 1),
                signingCredentials: credentials
            );
        }
    }

