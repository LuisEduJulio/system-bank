using api_bank.application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace api_bank.ioc.Register
{
    public static class IocExtensionAutoMappers
    {
        public static void RegisterAutoMappers(this IServiceCollection services)
        {
            services
                 .AddAutoMapper(typeof(MapperCustomerProfile))
                 .AddAutoMapper(typeof(MapperExtractProfile))
                 .AddAutoMapper(typeof(MapperBankProfile));
        }
    }
}