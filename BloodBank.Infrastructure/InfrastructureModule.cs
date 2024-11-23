using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDataBase(configuration)
                .AddRepositories();
            return services;
        }
        private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloodBankDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BloodBankCs")));
            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>()
                    .AddScoped<IDonationRepository, DonationRepository>()
                    .AddScoped<IDonorRepository, DonorRepository>();
            return services;
        }
    }
}