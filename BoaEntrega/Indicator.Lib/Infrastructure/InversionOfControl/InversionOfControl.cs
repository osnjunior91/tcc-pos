using Indicator.Lib.Infrastructure.HttpClient.Customer;
using Indicator.Lib.Infrastructure.HttpClient.Order;
using Indicator.Lib.Infrastructure.HttpClient.Utils;
using Indicator.Lib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicator.Lib.Infrastructure.InversionOfControl
{
    public static class InversionOfControl
    {
        public static void AddInversionOfControl(this IServiceCollection services)
        {
            services.AddScoped<IIndicatorService, IndicatorService>();
            services.AddScoped<IOrderApi, OrderApi>();
            services.AddScoped<ICustomerApi, CustomerApi>();
            services.AddScoped<IUtilsApi, UtilsApi>();
        }
    }
}
