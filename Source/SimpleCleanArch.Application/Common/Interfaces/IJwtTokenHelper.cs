using SimpleCleanArch.Application.Common.Models;
using System.Security.Claims;

namespace SimpleCleanArch.Application.Common.Interfaces
{
    public interface IJwtTokenHelper
    {
        JwtToken GetJwtToken(string username, string signingKey, string issuer,
                                                   string audience, TimeSpan expiration, Claim[] additionalClaims = null!);
    }
}
