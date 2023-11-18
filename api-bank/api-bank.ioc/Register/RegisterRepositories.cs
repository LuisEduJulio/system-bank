using api_bank.domain.Repositories;
using api_bank.infraestructure.Repositories;
using api_doc_rabbitmq.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace api_bank.ioc.Register
{
    public static class IocExtensionRepositories
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IExtractRepository, ExtractRepository>()
                .AddTransient<IBankRepository, BankRepository>()
                .AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
