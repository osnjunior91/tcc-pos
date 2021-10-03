using Microsoft.Extensions.DependencyInjection;
using Utils.Lib.Infrastructure.HttpClient.Geo;
using Utils.Lib.Services;

namespace Utils.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped<IGeoService, GeoService>();
            services.AddScoped<IGoogleMapsApi, GoogleMapsApi>();
        }
    }
}
