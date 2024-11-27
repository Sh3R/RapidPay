using Microsoft.Extensions.DependencyInjection;
using RapidPay.Application.Repository;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Infrastructure.Context;
using RapidPay.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RapidPay.Infrastructure.Repository.CardRepository;
using RapidPay.Application.Repository.PaymentRepository;
using RapidPay.Infrastructure.Repository.PaymntRepository;

namespace RapidPay.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("RapidContext");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("RapidPay.Infrastructure")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}