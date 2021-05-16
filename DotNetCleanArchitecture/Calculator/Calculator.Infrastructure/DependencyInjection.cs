using Calculator.Application.Services;
using Calculator.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCalculatorInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddTransient<IExchangeRateService, ExchangeRateService>();

            return services;
        }
    }
}