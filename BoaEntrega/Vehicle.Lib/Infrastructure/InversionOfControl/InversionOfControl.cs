using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.Lib.Infrastructure.HttpClient.Warehouse;
using Vehicle.Lib.Services;

namespace Vehicle.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IWarehouseApi, WarehouseApi>();
        }
    }
}
