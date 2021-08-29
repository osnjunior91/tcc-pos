using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Customer.Lib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
