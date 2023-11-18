using api_bank.application.Services;
using api_bank.domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api_bank.ioc.Register
{
    public static class IocExtensionServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services
                .AddTransient<IExtractService, ExtractService>()
                .AddTransient<IBankService, BankService>()
                .AddTransient<ICustomerService, CustomerService>();
        }
    }
}