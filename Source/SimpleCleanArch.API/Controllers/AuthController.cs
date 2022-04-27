using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.API.ViewModels;
using SimpleCleanArch.Application.Common.Constants;
using SimpleCleanArch.Application.Common.Extensions;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Infrastructure.Identity;
using System.Security.Claims;

namespace SimpleCleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController(ILogger<AuthController> logger, IConfiguration configuration
            , IJwtTokenHelper jwtTokenHelper
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _configuration = configuration;
            _jwtTokenHelper = jwtTokenHelper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel vm)
        {
            try
            {
                await Task.Delay(500);

                // My application logic to validate the user
                #region MOCK
                //AuthenticationModel authentication = new AuthenticationModel();
                //var user = authentication.Login(vm.UserName, vm.PassWord);
                #endregion
                var user = await _userManager.FindByNameAsync(vm.UserName);
                if (user is null)
                {
                    return BadRequest("User not found!");
                }
                var singin = await _signInManager.PasswordSignInAsync(user, vm.PassWord, false, false);
                if (!singin.Succeeded)
                {
                    return BadRequest("Invalid password");
                }

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, vm.UserName ?? "")); // NameIdentifier is the ID for an object
                claims.Add(new Claim(ClaimTypes.Name, vm.UserName ?? "")); //  Name is just that a name       

                var userRoles = await _userManager.GetRolesAsync(user);
                var userClaims = await _userManager.GetClaimsAsync(user);

                // Add roles as multiple claims
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Optionally add other app specific claims as needed
                foreach (var item in userClaims)
                {
                    claims.Add(new Claim(item.Type, item.Value));
                }


                // create a new token with token helper and add our claim
                var token = _jwtTokenHelper.GetAccessToken(vm.UserName ?? "", claims);


                // this need to be saved in database
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Constants.JwtSettings.RefreshTokenExpiryMinutes);

                var res = await _userManager.UpdateAsync(user);

                return Ok(new { UserName = user.UserName, roles = userRoles, claims = userClaims, token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetExceptions());
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Ok(response);
        }
    }
}
