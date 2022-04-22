﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.API.ViewModels;
using SimpleCleanArch.Application.Common.Constants;
using SimpleCleanArch.Application.Common.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleCleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] LoginModel vm)
        {
            await Task.Delay(500);

            // My application logic to validate the user
            Authentication authentication = new Authentication();
            var user = authentication.Login(vm.UserName, vm.PassWord);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return NotFound(response);
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, vm.UserName ?? "")); // NameIdentifier is the ID for an object
            claims.Add(new Claim(ClaimTypes.Name, vm.UserName ?? "")); //  Name is just that a name       

            // Add roles as multiple claims
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Optionally add other app specific claims as needed
            claims.Add(new Claim("Depertment", user.Depertment));

            // create a new token with token helper and add our claim
            var token = JwtTokenHelper.GetJwtToken(vm.UserName ?? "",
                Constants.JwtToken.SigningKey,
                Constants.JwtToken.Issuer,
                Constants.JwtToken.Audience,
                TimeSpan.FromMinutes(Constants.JwtToken.TokenTimeoutMinutes),
                claims.ToArray());

            response.Data = token;
            return Ok(response);
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
