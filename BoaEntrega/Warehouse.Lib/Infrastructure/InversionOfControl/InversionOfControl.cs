using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Lib.Services;

namespace Warehouse.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IWarehouseService, WarehouseService> ();
        }
    }
}
