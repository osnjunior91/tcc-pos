using Microsoft.Extensions.DependencyInjection;
using Utils.Lib.Services;

namespace Utils.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped<IGeoService, GeoService>();
        }
    }
}
