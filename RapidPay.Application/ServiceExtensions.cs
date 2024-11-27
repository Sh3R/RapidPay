using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Application.Common.Behaviours;
using RapidPay.Application.Helpers.Pasword;
using RapidPay.Application.Repository.PaymentRepository;
using RapidPay.Application.Services.Auth;
using RapidPay.Application.Services.Fee;
using RapidPay.Application.Services.Payment;
using RapidPay.Application.Services.User;
using RapidPay.Domain.Entities;
using System.Reflection;

namespace RapidPay.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IFeeService, FeeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }
    }
}