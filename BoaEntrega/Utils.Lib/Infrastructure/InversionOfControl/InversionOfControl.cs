using Microsoft.Extensions.DependencyInjection;
using Utils.Lib.Infrastructure.HttpClient.Geo;
using Utils.Lib.Infrastructure.HttpClient.Warehouse;
using Utils.Lib.Services;

namespace Utils.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped<IGeoService, GeoService>();
            services.AddScoped<IPortageService, PortageService>();
            services.AddScoped<IGoogleMapsApi, GoogleMapsApi>();
            services.AddScoped<IWarehouseApi, WarehouseApi>();
        }
    }
}
