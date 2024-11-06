using Microsoft.Extensions.DependencyInjection;
using User_Registration_Demo.Core.Services;
using User_Registration_Demo.Domain.Contracts.Core;
using User_Registration_Demo.Domain.Contracts.Repository;
using User_Registration_Demo.Infrastructure.Repository;

namespace User_Registration_Demo.IOC.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IUserServicesRepository, UserServicesRepository>();
            services.AddScoped<IUserServicesCore, UserServicesCore>();
            services.AddScoped<ISubscriptionServicesRepository, SubscriptionServicesRepository>();
            services.AddScoped<ISubscriptionServicesCore, SubscriptionServicesCore>();
            return services;
        }
    }
}
