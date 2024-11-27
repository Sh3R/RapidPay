using Microsoft.Extensions.Options;
using RapidPay.Application.Services.User;
using Microsoft.AspNetCore.Http;
using RapidPay.Infrastructure.Helpers;
using RapidPay.Application.Services.Auth;

namespace RapidPay.Infrastructure.Auth
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSetting _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSetting> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, ITokenService tokenService)
        {
            //get data from Header and validate
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = tokenService.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await userService.GetById(userId);
            }
            await _next(context);
        }
    }
}
