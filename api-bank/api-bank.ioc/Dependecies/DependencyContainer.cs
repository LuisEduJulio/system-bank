using api_bank.domain.Dtos.BankDto;
using api_bank.infraestructure.Entities;
using api_bank.infraestructure.Factory;
using api_bank.ioc.Register;
using api_bank.utility.Helpers;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace api_bank.ioc.Dependecies
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterIocDependencies(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services
               .AddMvc();

            Services
               .AddHttpClient();

            Services
                .AddControllers();

            Services
               .RegisterAutoMappers();

            Services
                .RegisterRepositories();

            Services
                .RegisterServices();

            Services
                .AddLogging();

            Services
            .AddFluentValidation(fv => fv
                .RegisterValidatorsFromAssemblyContaining<AddBankDto>());

            Services
                .Configure<AppSettings>(Configuration);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            Services
                .AddDbContext<AppDbContext>(options => options
                   .UseSqlServer(Configuration
                       .GetConnectionString("SqlServerConnection")));

            var appSettings = configuration.Get<AppSettings>();

            Services.AddCors(c =>
            {
                c.AddPolicy(EnvironmentHelper.GetCross(),
                    options => options
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(EnvironmentHelper.GetVersionApi(),
                    new OpenApiInfo
                    {
                        Title = EnvironmentHelper.GetApplicationName(),
                        Version = EnvironmentHelper.GetVersionApi()
                    });
            });

            Services.AddEndpointsApiExplorer();

            Services.AddAuthorization();

            return Services;
        }
    }
}