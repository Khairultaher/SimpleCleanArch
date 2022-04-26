using SimpleCleanArch.Application.Common.Models;
using System.Security.Claims;

namespace SimpleCleanArch.Application.Common.Interfaces
{
    public interface IJwtTokenHelper
    {
        JwtTokenModel GetAccessToken(string username, IEnumerable<Claim> claims);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string signingKey);
    }
}
