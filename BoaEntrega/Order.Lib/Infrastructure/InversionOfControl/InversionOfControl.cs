using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Order.Lib.Infrastructure.HttpClient.Customer;
using Order.Lib.Infrastructure.HttpClient.Product;
using Order.Lib.Infrastructure.HttpClient.Utils;
using Order.Lib.Infrastructure.HttpClient.Warehouse;
using Order.Lib.Services;

namespace Order.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerApi, CustomerApi>();
            services.AddScoped<IWarehouseApi, WarehouseApi>();
            services.AddScoped<IProductApi, ProductApi>();
            services.AddScoped<IUtilsApi, UtilsApi>();
        }
    }
}
