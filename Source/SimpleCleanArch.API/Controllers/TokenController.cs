
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.API.ViewModels;
using SimpleCleanArch.Application.Common.Constants;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Application.Common.Models;

namespace SimpleCleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly IJwtTokenHelper _tokenService;
        public TokenController(IJwtTokenHelper tokenService)
        {
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(JwtTokenModel tokenModel)
        {
            if (tokenModel is null)
                return BadRequest("Invalid client request");
            string accessToken = tokenModel.AccessToken;
            string refreshToken = tokenModel.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken, Constants.JwtSettings.SigningKey);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            AuthenticationModel authentication = new AuthenticationModel();
            var user = authentication.Users.SingleOrDefault(u => u.UserName == username);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Invalid client request");

            var token = _tokenService.GetAccessToken(user.UserName, principal.Claims);
            user.RefreshToken = token.RefreshToken;


            // update database
            //_userContext.SaveChanges();

            return Ok(new { UserName = user.UserName, roles = user.Roles, token = token });
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            AuthenticationModel authentication = new AuthenticationModel();
            var user = authentication.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;

            // update database
            //_userContext.SaveChanges();

            return NoContent();
        }
    }
}
