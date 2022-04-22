using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Application.Common.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleCleanArch.Infrastructure.Security
{
    public class JwtTokenHelper : IJwtTokenHelper
    {
        public JwtToken GetJwtToken(string username, string signingKey, string issuer,
                                                   string audience, TimeSpan expiration, Claim[] additionalClaims = null!)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                // this guarantees the token is unique
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (additionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.Add(expiration),
                claims: claims,
                signingCredentials: creds
            );

            var strJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return JsonConvert.DeserializeObject<JwtToken>(strJwt);
        }
    }
}
