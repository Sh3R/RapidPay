using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Controllers.Base;
using RapidPay.Application.Helpers.Pasword;
using RapidPay.Application.Services.Auth;
using RapidPay.Application.Services.User;
using RapidPay.Domain.Entities;
using RapidPay.Infrastructure.Helpers;

namespace RapidPay.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IPasswordHelper _passwordHelper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(IMediator mediator, ITokenService tokenService, IPasswordHelper passwordHelper, IUserService userService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
            _passwordHelper = passwordHelper;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RegisterRequest userRequst)
        {
            User? user = await _userService.FindByUsernameAsync(userRequst.Username);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var result = _passwordHelper.VerifyPassword(user, user.Password, userRequst.Password);

            if (!result)
            {
                return Unauthorized("Invalid credentials");
            }

            var authClaims = ApiAuthenticationHelper.GetClaims(user);
            // Generate token
            var token = _tokenService.CreateToken(user, authClaims);

            // Return the token
            return Ok(new { Token = token });
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = new User
                {
                    UserName = request.Username,
                    Password = _passwordHelper.HashPassword(null, request.Password),
                    Active = true,
                };

                var createUserResult = await _userService.CreateUser(user);
                if (createUserResult.Succeeded)
                {
                    var authClaims = ApiAuthenticationHelper.GetClaims(user);
                    var token = _tokenService.CreateToken(user, authClaims);
                    return Ok(new { Token = token });
                }
                return Ok(new { Error = createUserResult.Errors });
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
    }
}